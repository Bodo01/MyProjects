#ifndef CREATEPOST_H
#define CREATEPOST_H

#include <QWidget>
#include <set>
#include "TcpSocket.h"
#include <QDateTime>

namespace Ui {
class CreatePost;
}

class CreatePost : public QWidget
{
    Q_OBJECT

public:
    explicit CreatePost(QWidget *parent = nullptr);
    ~CreatePost();
    int textLenght();
    void setWriteAcces(bool);
    void SetUsername(const std::string& username){
        m_username = username;
    }

private slots:
    void on_pushButton_clicked();

    void on_uploadbutton_clicked();

private:
    Ui::CreatePost *ui;
    std::vector <std::string> pictures;
    std::string m_username;
};

#endif // CREATEPOST_H
