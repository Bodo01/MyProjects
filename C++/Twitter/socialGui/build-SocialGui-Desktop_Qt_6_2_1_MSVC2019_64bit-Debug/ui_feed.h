/********************************************************************************
** Form generated from reading UI file 'feed.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_FEED_H
#define UI_FEED_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QListWidget>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Feed
{
public:
    QPushButton *pushButton;
    QPushButton *pushButton_2;
    QListWidget *listWidget;
    QPushButton *pushButton_3;
    QTextEdit *textEdit;
    QPushButton *pushButton_4;

    void setupUi(QWidget *Feed)
    {
        if (Feed->objectName().isEmpty())
            Feed->setObjectName(QString::fromUtf8("Feed"));
        Feed->resize(1313, 663);
        QFont font;
        font.setPointSize(9);
        Feed->setFont(font);
        Feed->setStyleSheet(QString::fromUtf8("background-color: rgb(235, 235, 222);"));
        pushButton = new QPushButton(Feed);
        pushButton->setObjectName(QString::fromUtf8("pushButton"));
        pushButton->setGeometry(QRect(1200, 600, 91, 41));
        pushButton->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"font: 9pt \"MS Shell Dlg 2\";\n"
"border-radius: 10px;\n"
"color: rgb(235, 235, 222);"));
        pushButton_2 = new QPushButton(Feed);
        pushButton_2->setObjectName(QString::fromUtf8("pushButton_2"));
        pushButton_2->setGeometry(QRect(1090, 600, 101, 41));
        pushButton_2->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"font: 9pt \"MS Shell Dlg 2\";\n"
"border-radius: 10px;\n"
"color: rgb(235, 235, 222);"));
        listWidget = new QListWidget(Feed);
        listWidget->setObjectName(QString::fromUtf8("listWidget"));
        listWidget->setGeometry(QRect(960, 0, 341, 441));
        QFont font1;
        font1.setPointSize(11);
        listWidget->setFont(font1);
        listWidget->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);"));
        pushButton_3 = new QPushButton(Feed);
        pushButton_3->setObjectName(QString::fromUtf8("pushButton_3"));
        pushButton_3->setGeometry(QRect(960, 540, 341, 41));
        QFont font2;
        font2.setPointSize(15);
        pushButton_3->setFont(font2);
        pushButton_3->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"border-radius: 15px;\n"
"color: rgb(235, 235, 222);"));
        textEdit = new QTextEdit(Feed);
        textEdit->setObjectName(QString::fromUtf8("textEdit"));
        textEdit->setGeometry(QRect(960, 450, 341, 81));
        QFont font3;
        font3.setPointSize(8);
        textEdit->setFont(font3);
        textEdit->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);"));
        pushButton_4 = new QPushButton(Feed);
        pushButton_4->setObjectName(QString::fromUtf8("pushButton_4"));
        pushButton_4->setGeometry(QRect(830, 600, 121, 41));
        QSizePolicy sizePolicy(QSizePolicy::Minimum, QSizePolicy::Fixed);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(pushButton_4->sizePolicy().hasHeightForWidth());
        pushButton_4->setSizePolicy(sizePolicy);
        pushButton_4->setFont(font1);
        pushButton_4->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"border-radius: 15px;\n"
"color: rgb(235, 235, 222);"));

        retranslateUi(Feed);

        QMetaObject::connectSlotsByName(Feed);
    } // setupUi

    void retranslateUi(QWidget *Feed)
    {
        Feed->setWindowTitle(QCoreApplication::translate("Feed", "Form", nullptr));
        pushButton->setText(QCoreApplication::translate("Feed", "Next Post", nullptr));
        pushButton_2->setText(QCoreApplication::translate("Feed", "Previous Post", nullptr));
        pushButton_3->setText(QCoreApplication::translate("Feed", "Comment", nullptr));
        pushButton_4->setText(QCoreApplication::translate("Feed", "Like this post", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Feed: public Ui_Feed {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_FEED_H
