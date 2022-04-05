/********************************************************************************
** Form generated from reading UI file 'viewyourprofile.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_VIEWYOURPROFILE_H
#define UI_VIEWYOURPROFILE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_ViewYourProfile
{
public:
    QLabel *imagelabel;
    QPushButton *uploadbutton;
    QLabel *label_2;
    QLineEdit *usernameedit_2;
    QLabel *label_3;
    QLabel *usernameLabel;
    QPushButton *pushButton;
    QPushButton *pushButton_2;
    QPushButton *viewposts;

    void setupUi(QWidget *ViewYourProfile)
    {
        if (ViewYourProfile->objectName().isEmpty())
            ViewYourProfile->setObjectName(QString::fromUtf8("ViewYourProfile"));
        ViewYourProfile->setEnabled(true);
        ViewYourProfile->resize(868, 556);
        ViewYourProfile->setStyleSheet(QString::fromUtf8("background-color: rgb(235, 235, 222);"));
        imagelabel = new QLabel(ViewYourProfile);
        imagelabel->setObjectName(QString::fromUtf8("imagelabel"));
        imagelabel->setGeometry(QRect(0, 0, 341, 291));
        imagelabel->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);"));
        imagelabel->setScaledContents(true);
        uploadbutton = new QPushButton(ViewYourProfile);
        uploadbutton->setObjectName(QString::fromUtf8("uploadbutton"));
        uploadbutton->setGeometry(QRect(360, 300, 191, 41));
        QFont font;
        font.setPointSize(10);
        uploadbutton->setFont(font);
        uploadbutton->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"border-radius: 20px;\n"
"color: rgb(235, 235, 222);"));
        label_2 = new QLabel(ViewYourProfile);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(0, 300, 81, 41));
        QFont font1;
        font1.setPointSize(12);
        font1.setBold(true);
        label_2->setFont(font1);
        label_2->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(235, 235, 222);"));
        usernameedit_2 = new QLineEdit(ViewYourProfile);
        usernameedit_2->setObjectName(QString::fromUtf8("usernameedit_2"));
        usernameedit_2->setGeometry(QRect(110, 360, 651, 91));
        usernameedit_2->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"font: 12pt \"MS Shell Dlg 2\";\n"
"border: none;"));
        label_3 = new QLabel(ViewYourProfile);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(0, 360, 111, 91));
        label_3->setFont(font1);
        label_3->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(235, 235, 222);"));
        usernameLabel = new QLabel(ViewYourProfile);
        usernameLabel->setObjectName(QString::fromUtf8("usernameLabel"));
        usernameLabel->setGeometry(QRect(80, 300, 261, 41));
        usernameLabel->setFont(font1);
        usernameLabel->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"color: rgb(235, 235, 222);"));
        usernameLabel->setAlignment(Qt::AlignCenter);
        pushButton = new QPushButton(ViewYourProfile);
        pushButton->setObjectName(QString::fromUtf8("pushButton"));
        pushButton->setGeometry(QRect(520, 40, 121, 91));
        pushButton->setStyleSheet(QString::fromUtf8("background-color: rgb(0, 0, 0);"));
        pushButton_2 = new QPushButton(ViewYourProfile);
        pushButton_2->setObjectName(QString::fromUtf8("pushButton_2"));
        pushButton_2->setGeometry(QRect(682, 38, 111, 91));
        pushButton_2->setStyleSheet(QString::fromUtf8("background-color: rgb(0, 0, 0);"));
        viewposts = new QPushButton(ViewYourProfile);
        viewposts->setObjectName(QString::fromUtf8("viewposts"));
        viewposts->setGeometry(QRect(300, 470, 261, 71));
        QFont font2;
        font2.setPointSize(24);
        viewposts->setFont(font2);
        viewposts->setStyleSheet(QString::fromUtf8("background-color: rgb(0, 0, 0);"));

        retranslateUi(ViewYourProfile);

        QMetaObject::connectSlotsByName(ViewYourProfile);
    } // setupUi

    void retranslateUi(QWidget *ViewYourProfile)
    {
        ViewYourProfile->setWindowTitle(QCoreApplication::translate("ViewYourProfile", "Form", nullptr));
        imagelabel->setText(QString());
        uploadbutton->setText(QCoreApplication::translate("ViewYourProfile", "Update profile picture", nullptr));
        label_2->setText(QCoreApplication::translate("ViewYourProfile", " Name:", nullptr));
        usernameedit_2->setText(QString());
        label_3->setText(QCoreApplication::translate("ViewYourProfile", " About me:", nullptr));
        usernameLabel->setText(QCoreApplication::translate("ViewYourProfile", "default", nullptr));
        pushButton->setText(QCoreApplication::translate("ViewYourProfile", "View followers", nullptr));
        pushButton_2->setText(QCoreApplication::translate("ViewYourProfile", "View follows", nullptr));
        viewposts->setText(QCoreApplication::translate("ViewYourProfile", "View my posts", nullptr));
    } // retranslateUi

};

namespace Ui {
    class ViewYourProfile: public Ui_ViewYourProfile {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_VIEWYOURPROFILE_H
