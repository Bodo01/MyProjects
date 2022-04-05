#ifndef DISPLAYPROFILE_H
#define DISPLAYPROFILE_H

#include <QWidget>
#include "feed.h"
#include "user.h"
namespace Ui {
class displayProfile;
}

class displayProfile : public QWidget
{
    Q_OBJECT

public:
    explicit displayProfile(QWidget *parent = nullptr, UserClass user=UserClass());
    ~displayProfile();


    void setUsername(std::string);
private slots:
    void on_viewpostsButton_clicked();

    void on_followButton_clicked();



private:
    Ui::displayProfile *ui;
    Feed *posts;
    UserClass user;
    std::string username;
};

#endif // DISPLAYPROFILE_H
