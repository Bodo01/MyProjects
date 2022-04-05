#pragma once
#include <iostream>
#include <windows.h>
#include <sqlext.h>
#include <sqltypes.h>
#include <sql.h>
#include <regex>
#include <set>




class DatabaseSQL
{
private:
	SQLHANDLE m_SQLEnvHandle = NULL;
	SQLHANDLE m_SQLConnectionHandle = NULL;
	SQLHANDLE m_SQLStatementHandle = NULL;
	SQLRETURN m_retCode = 0;
	std::wstring m_dbName = L"pac";
	
public:
	void ShowSQLError(unsigned int handleType, const SQLHANDLE& handle);
	void ConnectDB(std::wstring url);
	void DisconnectDB();
	void Action(const std::wstring& SQLQuery);
	bool UserExists(const std::wstring&);
	bool UserPass(const std::wstring&, const std::wstring&);
	bool LoginUser(const std::wstring&);
	const std::string AddPost(const std::wstring&);
	std::string GetFeed(std::string mess);
	std::string AddComment(const std::wstring&);
	std::string GetComment(const std::wstring&);
	std::string GetLike(const std::wstring&);

	std::vector<std::string> GetUsernames();
	const std::string RegisterUser(const std::wstring&);
	const std::wstring GetDBName()const;
	const std::wstring ConvertStringToWstring(const std::string& s)const;
	const std::string ConvertWstringToString(const std::wstring& ws)const ;
	std::string GetProfileImage(const std::string& username);
	std::string GetUser(const std::wstring& );
	std::string AddLike(const std::wstring& data);
	std::vector<std::set<int>> GetGraph();
	bool Follow(int, int );
	int GetId(std::string);
	std::string GetUsername(int);
};

