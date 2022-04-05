#ifndef FOLLOW_H
#define FOLLOW_H

#include <QWidget>

namespace Ui {
class Follow;
}

class Follow : public QWidget
{
    Q_OBJECT

public:
    explicit Follow(QWidget *parent = nullptr);
    ~Follow();
    void addfollow(QString);

private:
    Ui::Follow *ui;
};

#endif // FOLLOW_H
