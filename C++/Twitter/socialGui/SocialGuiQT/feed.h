#ifndef FEED_H
#define FEED_H

#include <QWidget>
#include <list>
#include "Post.h"
#include <QLabel>
#include "TcpSocket.h"
#include <regex>

namespace Ui {
class Feed;
}

class Feed : public QWidget
{
    Q_OBJECT

public:
    explicit Feed(QWidget *parent = nullptr,std::list<Post> feedlist1=std::list<Post>());
    ~Feed();
    void InitFeed();
    void showEvent(QShowEvent *event);
    void comment(int,std::string);
    void SetUsername(const std::string&);
    const std::string GetUsername()const;
private slots:
    void on_pushButton_2_clicked();

    void on_pushButton_clicked();

    void displayPost(std::list<Post>::iterator);

    void on_pushButton_3_clicked();

    void on_pushButton_4_clicked();

private:
    Ui::Feed *ui;
    std::list<Post> feedList;

    std::list<Post>::iterator feedIt;
    std::string m_username;
    QLabel *text;
    QLabel *image;
    QLabel *likes;

};

#endif // FEED_H
