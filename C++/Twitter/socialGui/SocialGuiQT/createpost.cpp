#include "createpost.h"
#include "ui_createpost.h"
#include <QMessageBox>
#include <QFileDialog>
#include <QImage>
#include <QDebug>

CreatePost::CreatePost(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::CreatePost),
    pictures()
{
    ui->setupUi(this);
    ui->imagelabel->setPixmap(QPixmap(QString("C:/Users/radub/Desktop/noimageloaded.png")));
}

CreatePost::~CreatePost()
{
    delete ui;
}

int CreatePost::textLenght()
{


       int diff = ui->plainTextEdit->toPlainText().length() - 140;

       QString newStr = ui->plainTextEdit->toPlainText();

    newStr.chop(diff);

    ui->plainTextEdit->setPlainText(newStr);

    QTextCursor cursor(ui->plainTextEdit->textCursor());

    cursor.movePosition(QTextCursor::End, QTextCursor::MoveAnchor);

    ui->plainTextEdit->setTextCursor(cursor);

       return diff;




}


void CreatePost::on_pushButton_clicked()
{
    QDateTime dateTime = dateTime.currentDateTime();
    QString dateTimeString = dateTime.toString("yyyy-MM-dd hh:mm:ss");


    int txtLnght=textLenght();
    if (txtLnght>0) {QMessageBox::information(this,"Text", QString("Message is %1 characters too long!").arg(txtLnght));
    }else
    {
    std::string postText = ui->plainTextEdit->toPlainText().toStdString();
    std::string response = TcpSocket::ReceiveAndSend("POST:USERNAME="+m_username+"TEXT="+postText+"DATE="+dateTimeString.toStdString());

    if(response == "DEFAULT"){
     QMessageBox::information(this,"Posted", QString("Post successfully uploaded"));
     CreatePost::~CreatePost();
    }

}}


void CreatePost::on_uploadbutton_clicked()
{
   QFileDialog * selectimage= new QFileDialog(this);

 //  selectimage->getOpenFileName();
  // selectimage->show();
if (pictures.size()==1)
 {  pictures.erase(pictures.begin());

     ui->imagelabel->setPixmap(QPixmap(QString("C:/Users/radub/Desktop/noimageloaded.png")));
}

    pictures.push_back(selectimage->getOpenFileName().toStdString());

    //qDebug() << QString::fromStdString( pictures[0]);

    if (pictures[0]=="") {
        pictures.erase(pictures.begin());
        ui->imagelabel->setPixmap(QPixmap(QString("C:/Users/radub/Desktop/noimageloaded.png")));}



if (pictures.size()==1)

    ui->imagelabel->setPixmap(QPixmap(QString::fromStdString(pictures[0])));
   //qDebug()<<


}

