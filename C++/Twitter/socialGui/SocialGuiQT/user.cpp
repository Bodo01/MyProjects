#include "user.h"


UserClass::UserClass(std::string str):
    u_username(str)
{

}

UserClass::UserClass(uint16_t, std::string)
{
}

UserClass::UserClass(int id,std::string name, std::string gender, std::string aboutyou):
    u_id(id),
    u_username(name),
    u_gender(gender),
    u_bio(aboutyou)
{

}



void UserClass::setBio(std::string bio)
{
    u_bio = bio;
}



std::string UserClass::getBio()
{
    return u_bio;
}

uint16_t UserClass::getID()
{
    return u_id;
}

std::string UserClass::getUsername()
{
    return u_username;
}



uint16_t UserClass::getNumberOfFriends()
{
    return u_friendsList.size();
}



