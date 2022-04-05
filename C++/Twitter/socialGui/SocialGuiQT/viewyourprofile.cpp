#include "viewyourprofile.h"
#include "ui_viewyourprofile.h"
#include <QFileDialog>
#include <QMessageBox>
#include<QPlainTextEdit>
#include "feed.h"
#include "Post.h"

ViewYourProfile::ViewYourProfile(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::ViewYourProfile)
{
    ui->setupUi(this);
    /*

    image= new QLabel(this);

    image->setGeometry(0, -420, 1000, 1000);
    //image->setAlignment(Qt::AlignBottom | Qt::AlignRight);
    image->setPixmap(QPixmap("C:/Users/dumit/OneDrive/Desktop/image.jpg"));

    friends = new QLabel(this);

    QFont friendsFont("Arial", 12, QFont::Bold);

    friends->setFont(friendsFont);
    //friends->setAlignment(Qt::AlignTop | Qt::AlignLeft);
    friends->setGeometry(width() - 300, height() - 480,1000,100);

    std::string friendsStr="Number of Friends: "+std::to_string(2);

    friends->setText(QString::fromStdString(friendsStr));


    name = new QLabel(this);

    QFont nameFont("Arial", 12, QFont::Bold);

    name->setFont(nameFont);

    name->setGeometry(0, height() - 480,1000,100);

    std::string nameStr="UwU";

    name->setText(QString::fromStdString(nameStr));

    const QString text = "imi place anime UwU";
    //ui->plainTextEdit->setPlainText(text);
    //int txtLnght=textLenght();
   // if (txtLnght>0) {QMessageBox::information(this,"Text", QString("Message is %1 characters too long!").arg(txtLnght));
   // }*/
}

void ViewYourProfile::showEvent(QShowEvent *event){
    ui->usernameLabel->setText(m_username.c_str());
}

void ViewYourProfile::on_editButton_clicked()
{
    //qDebug() << "ceva";
    QMessageBox::information(this, "title", "profilu meu");
}

// ViewYourProfile::textLenght()
//{
    //int diff = ui->plainTextEdit->toPlainText().length() - 140;

    //QString newStr = ui->plainTextEdit->toPlainText();

 //newStr.chop(diff);

 //ui->plainTextEdit->setPlainText(newStr);

 //QTextCursor cursor(ui->plainTextEdit->textCursor());

 //cursor.movePosition(QTextCursor::End, QTextCursor::MoveAnchor);

 //ui->plainTextEdit->setTextCursor(cursor);

   // return diff;
//}



ViewYourProfile::~ViewYourProfile()
{

    delete ui;
}

void ViewYourProfile::on_viewposts_clicked()
{
    std::list<Post> feedList;
    const std::string response = TcpSocket::ReceiveAndSend("FEED:"+m_username);


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
    //feed->SetUsername(m_username);
    feed->show();

}


void ViewYourProfile::on_pushButton_2_clicked()
{
    ui->listWidget->clear();
    const std::string response = TcpSocket::ReceiveAndSend("VIEWFOLLOWS:"+m_username);

    std::regex rgx("NAMES=(.*).*");
    std::smatch match;

    std::regex_search(response.begin(), response.end(), match, rgx);


    QString inputDataId = match[1].str().c_str();
    QStringList stringListId = inputDataId.split('$');


     ui->listWidget->addItem("FOLLOWS");
    for (int i=1;i<stringListId.size();i++)
        ui->listWidget->addItem(stringListId[i]);


}


void ViewYourProfile::on_pushButton_clicked()
{
    ui->listWidget->clear();


    const std::string response = TcpSocket::ReceiveAndSend("VIEWFOLLOWERS:"+m_username);

    std::regex rgx("NAMES=(.*).*");
    std::smatch match;

    std::regex_search(response.begin(), response.end(), match, rgx);


    QString inputDataId = match[1].str().c_str();
    QStringList stringListId = inputDataId.split('$');

     ui->listWidget->addItem("FOLLOWERS");
    for (int i=1;i<stringListId.size();i++)
        ui->listWidget->addItem(stringListId[i]);
}

