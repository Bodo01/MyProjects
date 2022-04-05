#include "registerpage.h"
#include "ui_registerpage.h"
#include <QFileDialog>
#include <QMessageBox>
#include <QDebug>

registerpage::registerpage(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::registerpage)
{
    ui->setupUi(this);
    ui->imagelabel->setPixmap(QPixmap(QString("C:/Users/radub/Desktop/noimageloaded.png")));


}


registerpage::~registerpage()
{
    delete ui;
}

void registerpage::on_uploadpicture_clicked()
{
    QFileDialog * selectimage= new QFileDialog(this);

    profilepicture=selectimage->getOpenFileName();

    if (profilepicture!="")
        ui->imagelabel->setPixmap(profilepicture);
    else  ui->imagelabel->setPixmap(QPixmap(QString("C:/Users/radub/Desktop/noimageloaded.png")));

}


void registerpage::on_pushButton_clicked()
{
    std::string username = ui->usernameedit->text().toStdString();
    std::string password = ui->passwordedit->text().toStdString();
    std::string date = ui->dateEdit->text().toStdString();
    std::string gender = ui->comboBox->currentText().toStdString();
    const QPixmap profile = ui->imagelabel->pixmap();


    QByteArray image = {"\0"};
    QBuffer buffer(&image);
    buffer.open(QIODevice::WriteOnly);
    profile.save(&buffer, "PNG");




    //qDebug()<<"ENCODED : "<<image.toStdString();
    /*
    QImage imagep;
    imagep.loadFromData(QByteArray::fromBase64(image.toBase64()), "PNG");
    ui->imagelabel->setPixmap(QPixmap::fromImage(imagep));*/
    std::string receiveStr = TcpSocket::ReceiveAndSend("REGISTER:USERNAME="+username+"PASSWORD="+password+"BIRTH="+date+"GENDER="+gender+"IMAGE="+image.toBase64().toStdString());





    int genderInt=0;
    if (gender=="male") genderInt=1;
    if (gender=="female") genderInt=2;

    //qDebug() << date;


    //check data with server






    bool ok = 1 ;

    if (receiveStr == "TAKEN")
    {
    QMessageBox::warning(this,"","Username already taken !");
    ok=0;
    }

   // if (receiveStr == "OK")
   // {
    //QMessageBox::warning(this,"","Your account has been successfully created !");
   // ok=1;
   // }

    //warning if username is taken
    /*
    if (password.size()<5)
    {
    QMessageBox::warning(this,"","Your address is too short");
    ok=0;
    }*/

    //warning if address is too short

    if (0)
    {

        QMessageBox::warning(this,"Too young","You must be at least 14 years old !");
        ok=0;

    }

    //checks age ON SERVER

    if (ok) {
            QMessageBox::information(this,"", "Account created !");

            this->~registerpage();

        }
}

