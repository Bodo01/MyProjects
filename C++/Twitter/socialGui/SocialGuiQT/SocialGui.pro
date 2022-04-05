QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

CONFIG += c++11
CONFIG += console

# You can make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

SOURCES += \
    Post.cpp \
    TcpSocket.cpp \
    createpost.cpp \
    displayprofile.cpp \
    feed.cpp \
    follow.cpp \
    keysearch.cpp \
    loginwidget.cpp \
    main.cpp \
    menu.cpp \
    registerpage.cpp \
    user.cpp \
    viewyourprofile.cpp \
    widget.cpp

HEADERS += \
    Post.h \
    TcpSocket.h \
    createpost.h \
    displayprofile.h \
    feed.h \
    follow.h \
    keysearch.h \
    loginwidget.h \
    menu.h \
    registerpage.h \
    user.h \
    viewyourprofile.h \
    widget.h

FORMS += \
    createpost.ui \
    displayprofile.ui \
    feed.ui \
    follow.ui \
    keysearch.ui \
    loginwidget.ui \
    menu.ui \
    registerpage.ui \
    viewyourprofile.ui \
    widget.ui

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target
