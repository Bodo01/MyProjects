#include "menu.h"
#include "ui_menu.h"
#include <QMessageBox>




Menu::Menu(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Menu)
{
    ui->setupUi(this);
}

Menu::~Menu()
{
    delete ui;
}

void Menu::on_CreatePost_clicked()
{
 createpost = new CreatePost();
 createpost->SetUsername(m_username);
 createpost->show();


}


void Menu::on_ViewProfile_clicked()
{
    viewyourprofile = new ViewYourProfile();
    viewyourprofile->SetUsername(m_username);
    viewyourprofile->show();


    std::array<char, 512> receiveBuffer = { " " };
    TcpSocket socket;
    qDebug()<<"sss";
    socket.Connect("192.168.2.114", 27015);


    std::string receiveStr;
    int revieved;
    std::string userAndPass = "PROFILE:USERNAME="+m_username;
    socket.Send(userAndPass.c_str(), userAndPass.size());

    socket.Receive(receiveBuffer.data(), receiveBuffer.size(), revieved);
    receiveStr = receiveBuffer.data();



}


bool operator <( Post c1, Post c2)
{
    return c1.GetPostDate() > c2.GetPostDate();
}

void Menu::on_feedButton_clicked()
{



    std::priority_queue<Post> prQueue;


    std::list<Post> feedList;
    const std::string response = TcpSocket::ReceiveAndSend("FEED:*");

//qDebug()<<QString::fromStdString(response);
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

//qDebug()<<stringListDate.size()<<stringListText<<stringListLikes.size()<<stringListNames.size()<<stringListId.size();

    for(int i =1; i < stringListId.size();i++){



        Post p;
        p.SetId(stringListId.at(i).toInt());


        p.SetLikes(stringListLikes.at(i).toInt());
        //qDebug()<<p.GetLikes();
        p.SetUsername(stringListNames.at(i).toStdString());
        p.SetText(stringListText.at(i).toStdString());
        p.SetPostDate(stringListDate.at(i).toStdString());
        p.SetLiked(0);


        prQueue.push(p);


    }



    while (prQueue.empty()==0)
    {feedList.push_back(prQueue.top());

        qDebug()<<prQueue.top().GetId();
        prQueue.pop();

    }

    feed = new Feed(nullptr,feedList);

    feed->SetUsername(m_username);

    feed->show();
    //feed->InitFeed();


}


void Menu::on_FollowButton_clicked()
{
    follow = new Follow();


    QString usernameToFollow = ui->followEdit->text();

    const std::string response = TcpSocket::ReceiveAndSend("USERSEARCH:USERNAME="+ usernameToFollow.toStdString());

    if (response =="USERNOTFOUND")
         QMessageBox::information(this,"", "User not found");
    else
    {

        std::regex rgx(".*ID=(.*)USERNAME=(.*)GENDER=(.*)ABOUTYOU=(.*).*");
        std::smatch match;

        if (std::regex_search(response.begin(), response.end(), match, rgx)){
            std::cout << "match: " << match[1] << " " << match[2] << '\n';
        }

        QString inputDataId = match[1].str().c_str();


        QString inputDataName = match[2].str().c_str();


        QString inputGender = match[3].str().c_str();


        QString inputBio = match[4].str().c_str();





        UserClass user(inputDataId.toInt(),inputDataName.toStdString(),inputGender.toStdString(),inputBio.toStdString());


       // qDebug() <<inputDataName<<inputGender<<inputBio;
        displayProfile *foundProfile = new displayProfile(nullptr, user);
        foundProfile->setUsername(m_username);
    //qDebug()<< user.getID();
        foundProfile->show();


    }
}


void Menu::on_keysearchButton_clicked()
{
    keysearch = new keySearch();

    QString text= ui->searchEdit->text();

    QStringList words=text.split(", ");


}

