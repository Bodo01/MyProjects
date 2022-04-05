#ifndef VIEWYOURPROFILE_H
#define VIEWYOURPROFILE_H

#include <QWidget>
#include <QLabel>
#include <QDebug>
#include <QPixmap>

namespace Ui {
class ViewYourProfile;
}

class ViewYourProfile : public QWidget
{
    Q_OBJECT

public:
    explicit ViewYourProfile(QWidget *parent = nullptr);
    void SetUsername(std::string username){
        m_username = username;
    }
    void showEvent(QShowEvent *event);


    int textLenght();
    void setWriteAcces(bool);

    ~ViewYourProfile();

private slots:

    void on_editButton_clicked();

    void on_viewposts_clicked();

    void on_pushButton_2_clicked();

    void on_pushButton_clicked();

private:
    Ui::ViewYourProfile *ui;

     QLabel *image;
     QLabel *friends;
     QLabel *name;
     std::string m_username;


};

#endif // VIEWYOURPROFILE_H
