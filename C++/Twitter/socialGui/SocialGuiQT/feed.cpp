#include "feed.h"
#include "ui_feed.h"
#include <QLabel>
#include <QDebug>

Feed::Feed(QWidget *parent,std::list<Post> feedlist1) :
    QWidget(parent),
    ui(new Ui::Feed),
    feedList(feedlist1)
{
    ui->setupUi(this);

/*
    image= new QLabel(this);

       image->setGeometry(0, 100,width()-ui->listWidget->width()-20,height()-170);
        image->setAlignment(Qt::AlignTop | Qt::AlignLeft);*/

    text= new QLabel(this);
            QFont postFont( "Arial", 14);
            text->setFont( postFont);

            text->setAlignment(Qt::AlignTop | Qt::AlignLeft);

            text->setGeometry(0,60,width()-ui->listWidget->width()-20,98);
            text->setStyleSheet("border: 2px solid black;");

    likes = new QLabel(this);

               QFont likesFont("Arial", 12, QFont::Bold);

               likes->setFont(likesFont);
               likes->setAlignment(Qt::AlignTop | Qt::AlignLeft);
            likes->setGeometry(0,height()-50,190,130);


/*
    std::vector<std::pair<uint16_t, std::string>> comments;
    comments.push_back(std::make_pair(13332,"Misto post bro "));
    comments.push_back(std::make_pair(86312,"Frumos ce sa zic "));
    comments.push_back(std::make_pair(9642,"Eu n-as posta asa ceva "));
    comments.push_back(std::make_pair(5652,"ai 10 lei pana maine? "));
    std::string testimage;
    Post testPost("Textul postarii este aici!",25,comments,1,testimage);

    //feedList.push_back(testPost);


    comments.clear();
    comments.push_back(std::make_pair(86312,"okok "));
    Post testPost2("Textul postarii este aici! ce sa a as  s ",102,comments,1,testimage);
*/

//
    //feedList.push_back(testPost2);


}
void Feed::comment(int postId ,std::string comm){

    std::string data = "COMMENT:ID="+std::to_string(postId)+"USERNAME="+m_username+"COMMENT="+comm;

    std::string response = TcpSocket::ReceiveAndSend(data);


}


void Feed::showEvent(QShowEvent *event){

    feedIt=feedList.begin();
   // qDebug()<<feedIt->GetText().c_str();

 if (feedList.size()!=0)
    displayPost(feedIt);

}

Feed::~Feed()
{
    delete ui;
}

void Feed::on_pushButton_2_clicked()
{

    if (feedIt!=feedList.begin())
    {feedIt--;
        ui->listWidget->clear();
        ui->textEdit->clear();

        displayPost(feedIt);



    }
}



void Feed::on_pushButton_clicked()
{
    feedIt++;
    if (feedIt==feedList.end())
    { feedIt--;
        // request a new post details from server

        //ui->listWidget->clear();
        //ui->textEdit->clear();

        //displayPost(feedIt);

    }
    else
    {
        ui->listWidget->clear();
        ui->textEdit->clear();

        displayPost(feedIt);


    }

}

void Feed::SetUsername(const std::string& username){
    m_username = username;
}
const std::string Feed::GetUsername()const{
    return m_username;
}

void Feed::displayPost(std::list<Post>::iterator it)
{

    const std::string response = TcpSocket::ReceiveAndSend("GETCOMMENT:ID="+std::to_string(it->GetId()));


    std::regex rgx(".*NAMES=(.*)COMMENTS=(.*).*");
    std::smatch match;

    if (std::regex_search(response.begin(), response.end(), match, rgx)){
        std::cout << "match: " << match[1] << " " << match[2] << '\n';
    }


    QString inputDataNames = match[1].str().c_str();
    QStringList stringListNames = inputDataNames.split('$');

    QString inputDataComments = match[2].str().c_str();
    QStringList stringListComments = inputDataComments.split('$');

    std::vector<std::pair<std::string, std::string>> comments;

    for(int i =1; i < stringListNames.size();i++){
        comments.push_back(std::make_pair(stringListNames.at(i).toStdString(),stringListComments.at(i).toStdString()));

    }

    it->SetComments(comments);


   text->setText(QString::fromStdString(it->GetText()));



   std::string likeStr="Number of likes: "+std::to_string(it->GetLikes());

    ui->UsernameLabel->setText(QString::fromStdString(it->GetUsername()));
   likes->setText(QString::fromStdString(likeStr));

   //ui->UsernameLabel->setText(it->GetUsername().c_str());
   for(int i =1; i < stringListNames.size();i++){
       ui->listWidget->addItem(QString::fromStdString(stringListNames.at(i).toStdString()+": "+stringListComments.at(i).toStdString()));

   }




   //image->setPixmap(QPixmap("C:/Users/radub/Desktop/dumitrel.jpg"));//link to image post

/*
   for (auto x : it->GetComments())
       ui->listWidget->addItem(QString::fromStdString("@"+std::to_string(x.first)+" Commented: "+x.second));
*/
}


void Feed::on_pushButton_3_clicked()
{
    std::string comm=ui->textEdit->toPlainText().toStdString();
    ui->listWidget->addItem(QString::fromStdString(m_username+": "+comm));
    ui->textEdit->setText("");
    comment(feedIt->GetId(),comm);
    //transfer to server
}


void Feed::on_pushButton_4_clicked()
{
    ui->listWidget->clear();
    ui->textEdit->clear();

    if (feedIt->GetLiked()==0)
    {feedIt->SetLikes(feedIt->GetLikes()+1);
    feedIt->SetLiked(1);
    }
    else
    {
        feedIt->SetLikes(feedIt->GetLikes()-1);
            feedIt->SetLiked(0);
    }
    displayPost(feedIt);

}

