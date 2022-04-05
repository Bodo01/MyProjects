#pragma once
#include <string>
#include <vector>
#include <iostream>

class Post
{
public:

    Post();
    Post(std::string, unsigned int, std::vector<std::pair<std::string, std::string>>, bool, std::string);

    void SetText(const std::string&);
    void SetLikes(const int);
    void SetComments(const std::vector<std::pair<std::string, std::string>>&);
    void SetRetweet(const bool);
    void SetPostDate(const std::string&);
    void SetId(int id);
    void SetUsername(const std::string& username){
        m_username = username;
    }

    const std::string GetText() const;
    const int GetLikes() const;
    const std::vector<std::pair<std::string, std::string>> GetComments() const;
    const bool GetRetweet() const;
    const std::string GetPostDate() const;
    const std::string GetUsername() const;

    const int GetId() const;

    const bool GetLiked();
    void SetLiked(bool);

private:

    int m_id;
    std::string m_username;
    std::string m_text;
    int m_likes;
    std::vector<std::pair<std::string, std::string>> m_comments;
    bool m_retweet;
    std::string m_postDate;
    std::string m_image;
    bool liked;
};

