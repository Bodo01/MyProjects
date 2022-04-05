#include "displayprofile.h"
#include "ui_displayprofile.h"
#include "feed.h"
#include <QMessageBox>

displayProfile::displayProfile(QWidget *parent, UserClass us) :
    QWidget(parent),
    ui(new Ui::displayProfile),
    user(us)
{
    ui->setupUi(this);

    //uneste info din "user" cu Qlabel urile din UI

    ui->username->setText(QString::fromStdString(us.getUsername()));
    ui->bio->setText(QString::fromStdString(us.getBio()));

}

displayProfile::~displayProfile()
{
    delete ui;
}

void displayProfile::on_viewpostsButton_clicked()
{
    std::list<Post> feedList;
    const std::string response = TcpSocket::ReceiveAndSend("FEED:"+user.getUsername());


    std::regex rgx(".*ID=(.*)NAMES=(.*)TEXT=(.*)DATES=(.*)LIKES=(.*).*");
    std::smatch match;

    if (std::regex_search(response.begin(), response.end(), match, rgx)){
        std::cout << "match: " << match[1] << " " << match[2] << '\n';
    }

    QString inputDataId = match[1].str().c_str();
    QStringList stringListId = inputDataId.split('$');

    QString inputDataNames = match[2].str().c_str();
    QStringList stringListNames = inputDataNames.split('$');

    QString inputDataText = match[3].str().c_str();
    QStringList stringListText = inputDataText.split('$');

    QString inputDataDate = match[4].str().c_str();
    QStringList stringListDate = inputDataDate.split('$');

    QString inputDataLikes = match[5].str().c_str();
    QStringList stringListLikes = inputDataLikes.split('$');

    for(int i =1; i < stringListNames.size();i++){


        Post p;
        p.SetId(stringListId.at(i).toInt());
        p.SetLikes(stringListLikes.at(i).toInt());
        p.SetUsername(stringListNames.at(i).toStdString());
        p.SetText(stringListText.at(i).toStdString());
        p.SetPostDate(stringListDate.at(i).toStdString());

        feedList.push_back(p);

    }




    Feed *feed = new Feed(nullptr,feedList);


    feed->SetUsername(username);
    feed->show();
    //feed->InitFeed();

}


void displayProfile::on_followButton_clicked()
{
const std::string response = TcpSocket::ReceiveAndSend("FOLLOW:"+std::to_string(user.getID())+username);

if (response=="FOLLOWED") QMessageBox::information(this,"", "User followed!");
 else QMessageBox::information(this,"", "User already followed!");

}

void displayProfile::setUsername(std::string usr)
{
    username=usr;
}

