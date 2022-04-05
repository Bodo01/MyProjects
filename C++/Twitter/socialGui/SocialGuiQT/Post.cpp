#include "Post.h"

Post::Post():
    m_text(" "),
    m_likes(0),
    m_comments(0),
    m_retweet(false),
    m_postDate(" ")
{
}

Post::Post(std::string text, unsigned int likes, std::vector<std::pair<std::string, std::string>> comments,
    bool retweet, std::string postDate):
    m_text(text),
    m_likes(likes),
    m_comments(comments),
    m_retweet(retweet),
    m_postDate(postDate)
{
}

void Post::SetText(const std::string& text)
{
    m_text = text;
}

void Post::SetLikes(int likes)
{
    m_likes = likes;
}

void Post::SetComments(const std::vector<std::pair<std::string, std::string>>& comments)
{
    m_comments = comments;
}

void Post::SetRetweet(const bool retweet)
{
    m_retweet = retweet;
}

void Post::SetPostDate(const std::string& postDate)
{
    m_postDate = postDate;
}

void Post::SetId(int id){
    m_id = id;
}

const std::string Post::GetText() const
{
    return m_text;
}

const std::string Post::GetUsername() const
{
    return m_username;
}

const int Post::GetLikes() const
{
    return m_likes;
}

const int Post::GetId() const{
    return m_id;
}

const bool Post::GetLiked()
{
    return liked;
}

void Post::SetLiked(bool lik)
{
    liked=lik;
}

const std::vector<std::pair<std::string, std::string>> Post::GetComments() const
{
    return m_comments;
}

const bool Post::GetRetweet() const
{
    return m_retweet;
}

const std::string Post::GetPostDate() const
{
    return m_postDate;
}

