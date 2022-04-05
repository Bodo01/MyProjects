#include <iostream>
#include <array>
#include <sstream>
#include "DatabaseSQL.h"
#include <regex>
#include <set>


//#include "../Logger/Logger.h"

#include "../Network/TcpSocket.h"

int minim(const int& a, const int& b)
{
	if (a > b) return b;
	else return a;
}


std::string FindUsername(std::string data) {

	const std::string s = data;
	std::regex rgx(".*USERNAME=(.*).*");
	std::smatch match;

	if (std::regex_search(s.begin(), s.end(), match, rgx))
		std::cout << "match: " << match[1] << '\n';

	std::string name = match[1].str();

	return name;

}

unsigned int edit_distance(const std::string& s1, const std::string& s2)
{
	const std::size_t len1 = s1.size(), len2 = s2.size();
	std::vector<std::vector<unsigned int>> d(len1 + 1, std::vector<unsigned int>(len2 + 1));

	d[0][0] = 0;
	for (unsigned int i = 1; i <= len1; ++i) d[i][0] = i;
	for (unsigned int i = 1; i <= len2; ++i) d[0][i] = i;

	for (unsigned int i = 1; i <= len1; ++i)
		for (unsigned int j = 1; j <= len2; ++j)

			d[i][j] = minim(minim(d[i - 1][j] + 1, d[i][j - 1] + 1), d[i - 1][j - 1] + (s1[i - 1] == s2[j - 1] ? 0 : 1));

	return d[len1][len2];
}

std::string SwitchAction(std::string mess, DatabaseSQL db, std::vector <std::string>& user_list, std::vector <std::set<int>>& social_graph) {
	
	if (std::regex_match(mess, std::regex("(LOGIN:)(.*)"))) {
		if (db.LoginUser(db.ConvertStringToWstring(mess))) {
			return "ACCEPT";
		}
	}
	else if (std::regex_match(mess, std::regex("(REGISTER:)(.*)"))) {

		std::string newName;

		std::regex rgx(".*USERNAME=(.*)PASSWORD=(.*)BIRTH=(.*)GENDER=(.*)IMAGE=(.*).*");
		std::smatch match;

		const std::string s = mess;

		if (std::regex_search(s.begin(), s.end(), match, rgx))
			std::cout << "match: " << match[1] << " " << match[2] << '\n';

		newName = match[1];

		if (db.RegisterUser(db.ConvertStringToWstring(mess)) != "TAKEN")
		{

			int newId = db.GetId(newName);
			


			if (newId>social_graph.size())
			social_graph.resize(newId+1,std::set<int>());
			
			user_list.emplace_back(newName);
		}

	}
	else if (std::regex_match(mess, std::regex("(POST:)(.*)"))) {


		return db.AddPost(db.ConvertStringToWstring(mess));

	}
	else if (std::regex_match(mess, std::regex("(FEED:)(.*)"))) {


		return db.GetFeed(mess);

	}
	else if (std::regex_match(mess, std::regex("(COMMENT:)(.*)"))) {


		return db.AddComment(db.ConvertStringToWstring(mess));

	}
	else if (std::regex_match(mess, std::regex("(GETCOMMENT:)(.*)"))) {


		return db.GetComment(db.ConvertStringToWstring(mess));

	}
	else if (std::regex_match(mess, std::regex("(LIKE:)(.*)"))) {


		return db.AddLike(db.ConvertStringToWstring(mess));

	}
	else if (std::regex_match(mess, std::regex("(LIKEPOST:)(.*)"))) {


		return db.GetLike(db.ConvertStringToWstring(mess));

	}
	else if (std::regex_match(mess, std::regex("(USERSEARCH:)(.*)")))
	{
		int minim = 8888888;
		int poz = 0;

		std::string name = FindUsername(mess);

		for (auto x = 0; x < user_list.size(); x++)
		{

			int val = edit_distance(user_list[x], name);
			if (val < minim) {
				minim = val;
				poz = x;
			}

		}
		if (minim < 5)
		{
			std::cout << user_list[poz] << '\n';
			return db.GetUser(db.ConvertStringToWstring(user_list[poz]));

		}
		else
		{
			return "USERNOTFOUND";
		}

	}
	else if (std::regex_match(mess, std::regex("(FOLLOW:)(.*)")))
	{

		//int id_toFollow=std::stoi(mess.substr(7, mess.size() - 1));

		std::string username;
		int followId;

		int i = 7;
		while (mess[i] >= '0' && mess[i] <= '9')
			i++;
		i--;
		username = mess.substr(i + 1, mess.size());
		followId = std::stoi(mess.substr(7, i));


		int followingId = db.GetId(username);
		if (social_graph[followingId].find(followId) == social_graph[followingId].end())
		{
			social_graph[followingId].insert(followId);
			db.Follow(followingId, followId);
			return "FOLLOWED";
		}
	
		else return "FAILEDTOFOLLOW";

	}
	else if (std::regex_match(mess, std::regex("(VIEWFOLLOWS:)(.*)")))
	{
	std::string name = mess.substr(12,mess.size());

	int id=db.GetId(name);

	std::string result = "NAMES=";
	for (auto x : social_graph[id])
	{
		std::string names = db.GetUsername(x);
		result += "$" + names;
	}

	return result;
	}
	else if (std::regex_match(mess, std::regex("(VIEWFOLLOWERS:)(.*)")))
	{
	std::string name = mess.substr(14, mess.size());

	int id = db.GetId(name);

	std::string result = "NAMES=";

	for (int i=0;i<social_graph.size();i++)
		if (social_graph[i].find(id) != social_graph[i].end())
		{
			std::string names = db.GetUsername(i);

			std::cout << names << "  ";

			result += "$" + names;
		}
	return result;
	}
	return "DEFAULT";
	
}

void StartServer(){
	std::vector <std::string> user_list;
	std::vector <std::set<int>> social_graph;
	DatabaseSQL db;
	do {
		std::cout << "Starting server" << std::endl;


		TcpSocket listener;
		listener.Listen(27015);
		// receive
		std::array<char, 512> receiveBuffer = { " " };

		int revieved;
		std::stringstream stream;
		//stream << "Thank you, I received " << revieved << " bytes from you";
		std::string message;//stream.str();

		
		db.ConnectDB(L"DRIVER={SQL Server}; SERVER=localhost, 1433; DATABASE=" + db.GetDBName() + L"; UID=admin01; PWD=jhsbfsdbjsbdddjju;");
		//db.Action(L"INSERT INTO test_persoana (nume, varsta) VALUES('dumitrel puslenghea', 20); ");
		user_list = db.GetUsernames();
		social_graph = db.GetGraph();

		//std::cout <<* social_graph[82].begin();

		std::cout << "Waiting for client to connect" << std::endl;
		TcpSocket client = listener.Accept();
		while (true)
		{

			client.Receive(receiveBuffer.data(), receiveBuffer.size(), revieved);
			message = receiveBuffer.data();
			std::cout << "Received: ";
			//std::copy(receiveBuffer.begin(), receiveBuffer.begin() + revieved, std::ostream_iterator<char>(std::cout, ""));
			std::cout << message << std::endl;
			//db.AddUser(db.ConvertStringToWstring(message));
			//db.RegisterUser(db.ConvertStringToWstring(message));
			// send
			message = SwitchAction(message, db, user_list,social_graph);

			bool result = client.Send(message.c_str(), message.size());
			if (result) {
				break;
			}

			std::cout << "Sending: " << message << " bytes" << std::endl;
			std::cout << "Closing server. Bye! :)" << std::endl;

		}
	} while (true);
	db.DisconnectDB();
}


int main()
{
	StartServer();
	/*
	DatabaseSQL db;
	db.ConnectDB(L"DRIVER={SQL Server}; SERVER=localhost, 1433; DATABASE=" + db.GetDBName() + L"; UID=admin; PWD=admin;");
	//db.Action(L"INSERT INTO test_persoana (nume, varsta) VALUES('dumitrel puslenghea', 20); ");
	//bool t = db.LoginUser(L"LOGIN:USERNAME=dumitrelPASSWORD=lelele");
	bool t = db.UserExists(L"");
	std::cout << t;*/
	return 0;
}