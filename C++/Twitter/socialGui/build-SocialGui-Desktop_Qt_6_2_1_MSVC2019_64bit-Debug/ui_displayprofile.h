/********************************************************************************
** Form generated from reading UI file 'displayprofile.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_DISPLAYPROFILE_H
#define UI_DISPLAYPROFILE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_displayProfile
{
public:
    QPushButton *followButton;
    QLabel *label;
    QLabel *label_2;
    QLabel *label_3;
    QPushButton *viewpostsButton;

    void setupUi(QWidget *displayProfile)
    {
        if (displayProfile->objectName().isEmpty())
            displayProfile->setObjectName(QString::fromUtf8("displayProfile"));
        displayProfile->resize(1245, 652);
        followButton = new QPushButton(displayProfile);
        followButton->setObjectName(QString::fromUtf8("followButton"));
        followButton->setGeometry(QRect(1010, 570, 201, 61));
        QFont font;
        font.setPointSize(12);
        followButton->setFont(font);
        label = new QLabel(displayProfile);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(10, 70, 291, 241));
        label->setStyleSheet(QString::fromUtf8("background-color: rgb(143, 255, 69);\n"
"background-color: rgb(72, 48, 255);"));
        label_2 = new QLabel(displayProfile);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(10, 330, 661, 181));
        label_2->setStyleSheet(QString::fromUtf8("background-color: rgb(153, 236, 255);\n"
"background-color: rgb(0, 0, 0);"));
        label_3 = new QLabel(displayProfile);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(10, 20, 281, 41));
        label_3->setStyleSheet(QString::fromUtf8("background-color: rgb(197, 103, 255);"));
        viewpostsButton = new QPushButton(displayProfile);
        viewpostsButton->setObjectName(QString::fromUtf8("viewpostsButton"));
        viewpostsButton->setGeometry(QRect(20, 560, 231, 71));
        QFont font1;
        font1.setPointSize(18);
        viewpostsButton->setFont(font1);

        retranslateUi(displayProfile);

        QMetaObject::connectSlotsByName(displayProfile);
    } // setupUi

    void retranslateUi(QWidget *displayProfile)
    {
        displayProfile->setWindowTitle(QCoreApplication::translate("displayProfile", "Form", nullptr));
        followButton->setText(QCoreApplication::translate("displayProfile", "Follow", nullptr));
        label->setText(QCoreApplication::translate("displayProfile", "poza", nullptr));
        label_2->setText(QCoreApplication::translate("displayProfile", "descriere", nullptr));
        label_3->setText(QCoreApplication::translate("displayProfile", "Nume", nullptr));
        viewpostsButton->setText(QCoreApplication::translate("displayProfile", "View posts", nullptr));
    } // retranslateUi

};

namespace Ui {
    class displayProfile: public Ui_displayProfile {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_DISPLAYPROFILE_H
