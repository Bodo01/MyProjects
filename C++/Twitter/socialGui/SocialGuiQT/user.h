#pragma once
#include <string>
#include <set>
#include <iostream>

class UserClass
{
public:
    enum user_gender {
        eMale,
        eFemale,
        eOther
    };
public:

    UserClass()=default;
    UserClass(std::string);
    UserClass(uint16_t, std::string);
    UserClass(int,std::string,std::string,std::string);

    void setBirthDate(std::string);
    void setAge(uint8_t);
    void setBio(std::string);
    std::string getBirthDate();
    uint16_t getAge();
    std::string getBio();
    uint16_t getID();
    std::string getUsername();
    uint16_t getNumberOfFriends();

private:
    int u_id;
    std::string u_username;

    std::string u_birth_date;
    std::string u_bio;
    std::string u_gender;
    std::set<uint16_t> u_friendsList;

};

