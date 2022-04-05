#ifndef MENU_H
#define MENU_H

#include <QWidget>
#include "createpost.h"
#include "viewyourprofile.h"
#include "feed.h"
#include "follow.h"
#include "keysearch.h"
#include "Post.h"
#include "TcpSocket.h"
#include <array>
#include <list>
#include "displayprofile.h"
#include <queue>

namespace Ui {
class Menu;
}

class Menu : public QWidget
{
    Q_OBJECT

public:
    explicit Menu(QWidget *parent = nullptr);
    ~Menu();

    void SetUsername(std::string username){
        m_username = username;
    }

private slots:


    void on_CreatePost_clicked();

    void on_ViewProfile_clicked();

    void on_feedButton_clicked();

    void on_FollowButton_clicked();

    void on_keysearchButton_clicked();

private:
    Ui::Menu *ui;
    CreatePost *createpost;
    ViewYourProfile *viewyourprofile;
    Feed *feed;
    Follow *follow;
    keySearch *keysearch;
    std::string m_username;


};

#endif // MENU_H
