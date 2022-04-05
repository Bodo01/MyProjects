#include "DatabaseSQL.h"
#include <codecvt>;
#include <locale>

void DatabaseSQL::ShowSQLError(unsigned int handleType, const SQLHANDLE& handle)
{
	SQLCHAR SQLState[1024];
	SQLCHAR message[1024];
	if (SQL_SUCCESS == SQLGetDiagRec(handleType, handle, 1, (SQLWCHAR*)SQLState, NULL, (SQLWCHAR*)message, 1024, NULL))
		// Returns the current values of multiple fields of a diagnostic record that contains error, warning, and status information
		std::cout << "SQL driver message: " << message << "\nSQL state: " << SQLState << "." << std::endl;
}

std::vector<std::string> DatabaseSQL::GetUsernames()
{
	Action(L"SELECT username FROM users_table;");


	std::vector<std::string> vect;
	std::string str;
	char aux[130] = "";
	TIMESTAMP_STRUCT ts;
	SQLLEN           len;
	int like;

	std::string date;

	while (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		// Fetches the next rowset of data from the result
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &aux, sizeof(aux), NULL);
		str = aux;
		vect.push_back(str);



	}
	return vect;
}

void DatabaseSQL::ConnectDB(std::wstring url)
{
	do {

		if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &m_SQLEnvHandle))
			// Allocates the environment
			break;

		if (SQL_SUCCESS != SQLSetEnvAttr(m_SQLEnvHandle, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, 0))
			// Sets attributes that govern aspects of environments
			break;

		if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_DBC, m_SQLEnvHandle, &m_SQLConnectionHandle))
			// Allocates the connection
			break;

		if (SQL_SUCCESS != SQLSetConnectAttr(m_SQLConnectionHandle, SQL_LOGIN_TIMEOUT, (SQLPOINTER)5, 0))
			// Sets attributes that govern aspects of connections
			break;
		
		SQLCHAR retConString[1024]; // Conection string
		switch (SQLDriverConnect(m_SQLConnectionHandle, NULL, (SQLWCHAR*)url.c_str(), SQL_NTS, (SQLWCHAR*)retConString, 1024, NULL, SQL_DRIVER_NOPROMPT)) {
			// Establishes connections to a driver and a data source
		case SQL_SUCCESS:
			break;
		case SQL_SUCCESS_WITH_INFO:
			break;
		case SQL_NO_DATA_FOUND:
			ShowSQLError(SQL_HANDLE_DBC, m_SQLConnectionHandle);
			m_retCode = -1;
			break;
		case SQL_INVALID_HANDLE:
			ShowSQLError(SQL_HANDLE_DBC, m_SQLConnectionHandle);
			m_retCode = -1;
			break;
		case SQL_ERROR:
			ShowSQLError(SQL_HANDLE_DBC, m_SQLConnectionHandle);
			m_retCode = -1;
			break;
		default:
			break;
		}

		if (m_retCode == -1)
			break;

	} while (FALSE);
}

void DatabaseSQL::DisconnectDB()
{
	SQLFreeHandle(SQL_HANDLE_STMT, m_SQLStatementHandle);
	SQLDisconnect(m_SQLConnectionHandle);
	SQLFreeHandle(SQL_HANDLE_DBC, m_SQLConnectionHandle);
	SQLFreeHandle(SQL_HANDLE_ENV, m_SQLEnvHandle);
	// Frees the resources and disconnects
}

void DatabaseSQL::Action(const std::wstring& SQLQuery)
{
	do {

		if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_STMT, m_SQLConnectionHandle, &m_SQLStatementHandle))
			// Allocates the statement
			break;

		if (SQL_SUCCESS != SQLExecDirect(m_SQLStatementHandle, (SQLWCHAR*)SQLQuery.c_str(), SQL_NTS)) {
			// Executes a preparable statement
			ShowSQLError(SQL_HANDLE_STMT, m_SQLStatementHandle);
			break;
		}

	} while (FALSE);
}

bool DatabaseSQL::UserExists(const std::wstring& username)
{
	std::string response;
	char name[256]="";
	Action(L"SELECT username FROM users_table WHERE username='"+ username +L"';");
	if (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &name, sizeof(name), NULL);
	}
	response = name;
	if (!response.empty()) {
		return true;
	}

	return false;
}

bool DatabaseSQL::UserPass(const std::wstring& username, const std::wstring& pass)
{
	std::string response;
	char rpassword[256] = "";
	Action(L"SELECT password FROM users_table WHERE username='" + username + L"';");
	if (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &rpassword, sizeof(rpassword), NULL);
	}
	response = rpassword;
	if (response == ConvertWstringToString(pass)) {
		return true;
	}


	return false;
}

bool DatabaseSQL::LoginUser(const std::wstring& userAndPassword)
{
	std::wstring user;
	std::wstring password;
	const std::string s = ConvertWstringToString(userAndPassword);
	std::regex rgx(".*USERNAME=(.*)PASSWORD=(.*).*");
	std::smatch match;
	
	if (std::regex_search(s.begin(), s.end(), match, rgx)) {
		if (UserExists(ConvertStringToWstring(match[1].str()))) {
			if (UserPass(ConvertStringToWstring(match[1].str()), ConvertStringToWstring(match[2].str()))) {
				return true;
			}
		}
	}
	return false;
			
}

const std::string DatabaseSQL::AddPost(const std::wstring& postStr)
{
	

	const std::string s = ConvertWstringToString(postStr);
	std::regex rgx(".*USERNAME=(.*)TEXT=(.*)DATE=(.*).*");
	std::smatch match;

	if (std::regex_search(s.begin(), s.end(), match, rgx))
		std::cout << "match: " << match[1] << " " << match[2] << '\n';
	
	Action(L"INSERT INTO posts_table (username, post_text, date) VALUES('" + ConvertStringToWstring(match[1].str())
		+ L"', '" + ConvertStringToWstring(match[2].str()) +L"', '" + ConvertStringToWstring(match[3].str()) + L"'); ");
	
	return "DEFAULT";

	
}

std::string DatabaseSQL::GetProfileImage(const std::string& username)
{
	const std::string s = username;
	std::regex rgx(".USERNAME=(.)*");
	std::smatch match;



	if (std::regex_search(s.begin(), s.end(), match, rgx))
		std::cout << "match: " << match[1] << " " << match[2] << '\n';
	char imgString[9999999];

	Action(L"SELECT iamge FROM users_table WHERE username='" + ConvertStringToWstring(match[1].str()) + L"';");
	if (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &imgString, sizeof(imgString), NULL);
	}



	return imgString;
}

std::string DatabaseSQL::AddComment(const std::wstring& data) {
	const std::string s = ConvertWstringToString(data);
	std::regex rgx(".*ID=(.*)USERNAME=(.*)COMMENT=(.*).*");
	std::smatch match;

	if (std::regex_search(s.begin(), s.end(), match, rgx))
		std::cout << "match: " << match[1] << " " << match[2] << '\n';

	Action(L"INSERT INTO comments_table (post_id, username, comment) VALUES(" + ConvertStringToWstring(match[1].str())
		+ L", '" + ConvertStringToWstring(match[2].str()) + L"', '" + ConvertStringToWstring(match[3].str()) + L"'); ");

	return "DEFAULT";
}
std::string DatabaseSQL::AddLike(const std::wstring& data) {
	const std::string s = ConvertWstringToString(data);
	std::regex rgx(".*LIKE:(.*)ID=(.*).*");
	std::smatch match;

	if (std::regex_search(s.begin(), s.end(), match, rgx))
		std::cout << "match: " << match[1] << " " << match[2] << '\n';

	Action(L"UPDATE posts_table SET likes ="+ConvertStringToWstring(match[1].str())+L"WHERE id = "+ ConvertStringToWstring(match[2].str()));

	return "DEFAULT";
}


std::string DatabaseSQL::GetComment(const std::wstring& data)
{
	const std::string s = ConvertWstringToString(data);
	std::regex rgx(".*ID=(.*)*");
	std::smatch match;

	if (std::regex_search(s.begin(), s.end(), match, rgx))
		std::cout << "match: " << match[1] << " " << match[2] << '\n';

	char name[200];
	std::vector<std::string> names;
	std::vector<std::string> comments;
	
	Action(L"SELECT username, comment FROM comments_table WHERE post_id =" + ConvertStringToWstring(match[1].str()));
	while (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		// Fetches the next rowset of data from the result
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &name, sizeof(name), NULL);
		names.push_back(std::move(name));
		SQLGetData(m_SQLStatementHandle, 2, SQL_C_DEFAULT, &name, sizeof(name), NULL);
		comments.push_back(std::move(name));
	
		//SQLGetData(m_SQLStatementHandle, 2, SQL_C_DEFAULT, &age, sizeof(age), NULL);
		// Retrieves data for a single column in the result set

	}

	std::string rez;
	rez += "NAMES=";
	for (int i = 0; i < names.size(); i++) {
		rez += "$" + names[i];
	}

	rez += "COMMENTS=";
	for (int i = 0; i < comments.size(); i++) {
		rez += "$" + comments[i];
	}

	return rez;
}

std::string DatabaseSQL::GetLike(const std::wstring& data)
{

	const std::string s = ConvertWstringToString(data);
	std::regex rgx(".*ID=(.*)*");
	std::smatch match;
	int like;

	if (std::regex_search(s.begin(), s.end(), match, rgx))
		std::cout << "match: " << match[1] << " " << match[2] << '\n';
	Action(L"SELECT likes FROM posts_table WHERE id =" + ConvertStringToWstring(match[1].str()));

	if (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &like, sizeof(like), NULL);
		
	}

	return std::to_string(like);
}

std::string DatabaseSQL::GetFeed(std::string mess)
{
	if (mess[5]=='*')
	Action(L"SELECT * FROM posts_table;");
	else
	{
		mess = "SELECT * FROM posts_table WHERE username='" + mess.substr(5, mess.size() - 1) + "';";
		std::cout << mess<<'\n\n';
		Action(std::wstring_convert<std::codecvt_utf8<wchar_t>>().from_bytes(mess));
	}

	std::vector<std::string> postId;
	std::vector<std::string> postContent;
	std::vector<std::string> names;
	std::vector<std::string> dates;
	std::vector<std::string> likes;
	std::string str;
	char aux[130]="";
	TIMESTAMP_STRUCT ts;
	SQLLEN           len;
	int like;
	int id;
	
	std::string date;
	
	while (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		// Fetches the next rowset of data from the result
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &id, sizeof(id), NULL);
		postId.push_back(std::to_string(id));
		SQLGetData(m_SQLStatementHandle, 2, SQL_C_DEFAULT, &aux, sizeof(aux), NULL);
		//str = aux;
		names.push_back(std::move(aux));
	

		SQLGetData(m_SQLStatementHandle, 3, SQL_C_DEFAULT, &aux, sizeof(aux), NULL);
		//str = aux;

		postContent.push_back(std::move(aux));
		SQLGetData(m_SQLStatementHandle, 4, SQL_C_TIMESTAMP, &ts, sizeof(ts), &len);
		
		date = std::to_string(ts.year)+"-"+std::to_string(ts.month) + "-" + std::to_string(ts.day) + " " + std::to_string(ts.hour) + ":" + std::to_string(ts.minute) + ":" + std::to_string(ts.second);
		dates.push_back(std::move(date));
		SQLGetData(m_SQLStatementHandle, 5, SQL_C_DEFAULT, &like, sizeof(like), NULL);
		likes.push_back(std::to_string(like));
		//SQLGetData(m_SQLStatementHandle, 2, SQL_C_DEFAULT, &age, sizeof(age), NULL);
		// Retrieves data for a single column in the result set
		
	}
	std::string rez;
	rez += "ID=";
	for (int i = 0; i < postId.size(); i++) {
		rez += "$" + postId[i];
	}

	rez += "NAMES=";
	for (int i = 0; i < names.size(); i++) {
		rez += "$" + names[i];
	}
	rez += "TEXT=";
	for (int i = 0; i < postContent.size(); i++) {
		rez += "$" + postContent[i];
	}
	rez += "DATES=";
	for (int i = 0; i < dates.size(); i++) {
		rez += "$" + dates[i];
	}
	rez += "LIKES=";
	for (int i = 0; i < likes.size(); i++) {
		rez += "$" + likes[i];
	}
	
	std::cout << rez;
	return rez;
}

const std::string DatabaseSQL::RegisterUser(const std::wstring& dataPassed)
{
	std::wstring user;
	std::wstring password;
	const std::string s = ConvertWstringToString(dataPassed);
	std::regex rgx(".*USERNAME=(.*)PASSWORD=(.*)BIRTH=(.*)GENDER=(.*)IMAGE=(.*).*");
	std::smatch match;

	if (std::regex_search(s.begin(), s.end(), match, rgx))
		std::cout << "match: " << match[1] << " " << match[2] << '\n';
	if (!UserExists(ConvertStringToWstring(match[1].str()))) {

		Action(L"INSERT INTO users_table (username, password, birth_date, gender, image) VALUES('" + ConvertStringToWstring(match[1].str())
			+ L"', '" + ConvertStringToWstring(match[2].str()) + L"', '" + ConvertStringToWstring(match[3].str()) + L"', '"
			+ ConvertStringToWstring(match[4].str()) + L"', '" + ConvertStringToWstring(match[5].str()) + L"'); ");
	}
	else {
		return "TAKEN";
	}
	return "DEFAULT";
	
}

const std::wstring DatabaseSQL::GetDBName()const 
{
	return m_dbName;
}



const std::wstring DatabaseSQL::ConvertStringToWstring(const std::string& s) const
{
	std::wstring ws(s.begin(), s.end());
	return ws;
}

const std::string DatabaseSQL::ConvertWstringToString(const std::wstring& ws) const
{
	std::string s(ws.begin(), ws.end());
	return s;
}

std::string DatabaseSQL::GetUser(const std::wstring& user_name)
{
	std::string response;
	char profile[256] = "";
	Action(L"SELECT * FROM users_table WHERE username='" + user_name + L"';");
	if (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		
		int x;
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &x, sizeof(x), NULL);
		
		response += "ID=";
	    response +=std::to_string(x);
		SQLGetData(m_SQLStatementHandle, 2, SQL_C_DEFAULT, &profile, sizeof(profile), NULL);

		response += "USERNAME=";
		response += profile;

		/*SQLGetData(m_SQLStatementHandle, 4, SQL_C_DEFAULT, &profile, sizeof(profile), NULL);
		response += "BIRTH=";
		response += profile;*/

		SQLGetData(m_SQLStatementHandle, 5, SQL_C_DEFAULT, &profile, sizeof(profile), NULL);

		response += "GENDER=";
		response += profile;

		char profile2[256] = " ";
		
		SQLGetData(m_SQLStatementHandle, 7, SQL_C_DEFAULT, &profile2, sizeof(profile2), NULL);
		response += "ABOUTYOU=";
		response += profile2;


		
	}
	std::cout << response;
	return response;



}

std::vector<std::set<int>> DatabaseSQL::GetGraph()
{

	std::vector<std::set<int>> graph;

	Action(L"SELECT max(id) FROM users_table;");
	while (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		
		int aux;
		SQLGetData(m_SQLStatementHandle, 1, SQL_C_SBIGINT, &aux, sizeof(aux), NULL);
		
		

		graph.resize(aux+1,std::set<int>());



	}


	
	Action(L"SELECT * FROM follows_table;");
	

	while (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {
		
		int aux,aux2;
		SQLGetData(m_SQLStatementHandle, 2, SQL_C_SBIGINT, &aux, sizeof(aux), NULL);
		
		SQLGetData(m_SQLStatementHandle, 3, SQL_C_SBIGINT, &aux2, sizeof(aux2), NULL);

		graph[aux].insert(aux2);



	}
	return graph;
}

bool DatabaseSQL::Follow(int id1,int id2)
{
	

	Action(L"SELECT * FROM follows_table WHERE following_id =" + ConvertStringToWstring(std::to_string(id1)) + L" AND followed_id = " + ConvertStringToWstring(std::to_string(id2)));
	if (SQLFetch(m_SQLStatementHandle) != SQL_SUCCESS)
	{
		Action(L"INSERT INTO follows_table (following_id, followed_id) VALUES( " + ConvertStringToWstring(std::to_string(id1))
			+ L" , " + ConvertStringToWstring(std::to_string(id2)) + L" ); ");
		return 1;
	}

	else return 0;
}

int DatabaseSQL::GetId(std::string username)
{
	Action(L"SELECT id FROM users_table WHERE username='" + ConvertStringToWstring(username) + L"';");

	int aux=-1;

	while (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {


		SQLGetData(m_SQLStatementHandle, 1, SQL_C_SBIGINT, &aux, sizeof(aux), NULL);


	}

	return aux;
}

std::string DatabaseSQL::GetUsername(int id)
{
	Action(L"SELECT username FROM users_table WHERE id= " + ConvertStringToWstring(std::to_string(id)) + L";");

	char aux[130] = "";

	while (SQLFetch(m_SQLStatementHandle) == SQL_SUCCESS) {


		SQLGetData(m_SQLStatementHandle, 1, SQL_C_DEFAULT, &aux, sizeof(aux), NULL);


	}

	return std::string(aux);
}
