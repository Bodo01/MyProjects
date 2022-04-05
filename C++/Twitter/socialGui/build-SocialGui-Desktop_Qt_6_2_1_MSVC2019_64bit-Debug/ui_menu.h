/********************************************************************************
** Form generated from reading UI file 'menu.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MENU_H
#define UI_MENU_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Menu
{
public:
    QLabel *label;
    QPushButton *CreatePost;
    QPushButton *ViewProfile;
    QPushButton *FollowButton;
    QPushButton *feedButton;
    QPushButton *keysearchButton;
    QLineEdit *followEdit;
    QLineEdit *searchEdit;

    void setupUi(QWidget *Menu)
    {
        if (Menu->objectName().isEmpty())
            Menu->setObjectName(QString::fromUtf8("Menu"));
        Menu->resize(1039, 654);
        Menu->setStyleSheet(QString::fromUtf8("\n"
"background-color: rgb(235, 235, 222);"));
        label = new QLabel(Menu);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(30, 0, 121, 61));
        QFont font;
        font.setPointSize(22);
        label->setFont(font);
        label->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(222, 222, 190);\n"
"border-radius: 20px;"));
        CreatePost = new QPushButton(Menu);
        CreatePost->setObjectName(QString::fromUtf8("CreatePost"));
        CreatePost->setGeometry(QRect(30, 80, 121, 51));
        QFont font1;
        font1.setPointSize(12);
        CreatePost->setFont(font1);
        CreatePost->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));
        ViewProfile = new QPushButton(Menu);
        ViewProfile->setObjectName(QString::fromUtf8("ViewProfile"));
        ViewProfile->setGeometry(QRect(30, 160, 171, 51));
        ViewProfile->setFont(font1);
        ViewProfile->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));
        FollowButton = new QPushButton(Menu);
        FollowButton->setObjectName(QString::fromUtf8("FollowButton"));
        FollowButton->setGeometry(QRect(30, 320, 121, 51));
        FollowButton->setFont(font1);
        FollowButton->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));
        feedButton = new QPushButton(Menu);
        feedButton->setObjectName(QString::fromUtf8("feedButton"));
        feedButton->setGeometry(QRect(30, 240, 121, 51));
        feedButton->setFont(font1);
        feedButton->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));
        keysearchButton = new QPushButton(Menu);
        keysearchButton->setObjectName(QString::fromUtf8("keysearchButton"));
        keysearchButton->setGeometry(QRect(30, 400, 171, 51));
        keysearchButton->setFont(font1);
        keysearchButton->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));
        followEdit = new QLineEdit(Menu);
        followEdit->setObjectName(QString::fromUtf8("followEdit"));
        followEdit->setGeometry(QRect(172, 323, 181, 51));
        followEdit->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(222, 222, 190);\n"
"border: none;"));
        searchEdit = new QLineEdit(Menu);
        searchEdit->setObjectName(QString::fromUtf8("searchEdit"));
        searchEdit->setGeometry(QRect(220, 400, 181, 51));
        searchEdit->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(222, 222, 190);\n"
"border: none;"));

        retranslateUi(Menu);

        QMetaObject::connectSlotsByName(Menu);
    } // setupUi

    void retranslateUi(QWidget *Menu)
    {
        Menu->setWindowTitle(QCoreApplication::translate("Menu", "Form", nullptr));
        label->setText(QCoreApplication::translate("Menu", " Menu", nullptr));
        CreatePost->setText(QCoreApplication::translate("Menu", "Create Post", nullptr));
        ViewProfile->setText(QCoreApplication::translate("Menu", "View you profile", nullptr));
        FollowButton->setText(QCoreApplication::translate("Menu", "Follow", nullptr));
        feedButton->setText(QCoreApplication::translate("Menu", "Feed", nullptr));
        keysearchButton->setText(QCoreApplication::translate("Menu", "Keyword search", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Menu: public Ui_Menu {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MENU_H
