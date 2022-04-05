package Classes;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.List;
import java.util.Scanner;

public class Admin {
    private int id;
    private String username;
    private Socket socket;
    private PrintWriter out;
    private Scanner in;
    private Scanner s;

    public Admin(int id, String username, Scanner s, Socket socket, PrintWriter out, Scanner in) throws IOException {

        this.id = id;
        this.username = username;
        this.s = s;
        this.socket = socket;
        this.out = out;
        this.in = in;


    }


    public void etapaNoua() throws IOException {

        out.println("ETAPE");

        String response = in.nextLine();

        ObjectMapper mapper = new ObjectMapper();

        List<Etapa> listaEtape = mapper.readValue(response, new TypeReference<List<Etapa>>() {
        });

        for (int i = 0; i < listaEtape.size(); i++) {
            System.out.println("Etapa id: " + listaEtape.get(i).getIdEtapa() + "  Denumire etapa: " +
                    listaEtape.get(i).getDenumire() + "  Incheiata: " + listaEtape.get(i).getIncheiata());


        }

        System.out.println("\nIntroduceti numele noii etape sau caracterul 0 pentru a anula introducerea:");

        String input = "";

        input = s.nextLine();

        if (input.equals("0")) return;
        else {
            out.println("NOUET" + input);

            response = in.nextLine();

            System.out.println(response);


        }

    }

    public void echipaNoua() throws IOException {

        out.println("ECHIP");

        String response = in.nextLine();

        ObjectMapper mapper = new ObjectMapper();

        List<Echipa> listaEchipe = mapper.readValue(response, new TypeReference<List<Echipa>>() {
        });

        for (int i = 0; i < listaEchipe.size(); i++) {
            System.out.println("Echipa id: " + listaEchipe.get(i).getIdEchipa() + "  Denumire echipa: " +
                    listaEchipe.get(i).getNumeEchipa());


        }

        System.out.println("\nIntroduceti caracterul 0 pentru a iesi, 1 pentru a crea o echipa noua 2 pentru a modifica numele unei echipe:");

        String input = "";

        input = s.nextLine();

        int choice = Integer.parseInt(input);

        while (true)
        {
            switch (choice){
                case 1:
                    System.out.println("Introduceti numele echipei");
                    input = s.nextLine();
                    out.println("NOUEC" + input);
                    System.out.println(in.nextLine());

                    return;
                case 0:
                    return;

                case 2:
                    System.out.println("Introduceti id-ul echipei");
                    String id_echipa = s.nextLine();
                    System.out.println("Introduceti numele echipei");
                    String nume_echipa = s.nextLine();

                    out.println("UPDEC"+"#"+id_echipa+"#"+nume_echipa);
                    System.out.println(in.nextLine());
                    return;
                default :
                    System.out.println("Nicio optiune valida selectata!");
            }

        }


    }

    public void persNoua() throws IOException {
        out.println("ECHIP");

        String response = in.nextLine();

        ObjectMapper mapper = new ObjectMapper();

        List<Echipa> listaEchipe = mapper.readValue(response, new TypeReference<List<Echipa>>() {
        });

        for (int i = 0; i < listaEchipe.size(); i++) {
            System.out.println("Echipa id: " + listaEchipe.get(i).getIdEchipa() + "  Denumire echipa: " +
                    listaEchipe.get(i).getNumeEchipa());


        }

        String id_echipa,nume,username;


        System.out.println("Introduceti id ul echipei in care doriti sa introduceti persoana noua:");
       id_echipa= s.nextLine();
        System.out.println("Introduceti numele persoanei:");
        nume= s.nextLine();
        System.out.println("Introduceti username-ul persoanei:");
        username=s.nextLine();

        String send ="NOUPE" +"#"+id_echipa+"#"+nume+"#"+username+"#" ;



        out.println(send);

        System.out.println(in.nextLine());


    }


    public void partFaraScor() throws IOException {

        out.println("ETAPE");

        String response = in.nextLine();

        ObjectMapper mapper = new ObjectMapper();

        List<Etapa> listaEtape = mapper.readValue(response, new TypeReference<List<Etapa>>() {
        });

        for (int i = 0; i < listaEtape.size(); i++) {
            System.out.println("Etapa id: " + listaEtape.get(i).getIdEtapa() + "  Denumire etapa: " +
                    listaEtape.get(i).getDenumire() + "  Incheiata: " + listaEtape.get(i).getIncheiata());


        }

        System.out.println("Introduceti id-ul etapei la care doriti sa vedeti participantii fara scor:");
        String input=s.nextLine();
        String id_etapa=input;
        out.println("FARAS"+input);

        response =in.nextLine();
        if (response.charAt(0)!='[')
         System.out.println( response);
       else
        {


            List<Participant> list = mapper.readValue(response, new TypeReference<List<Participant>>() {});

            if (list==null) System.out.println("Nu exista participanti fara scor in etapa selectata!");
            else {
                System.out.println("Participanti fara scor in etapa " + input);
                for (int i = 0; i < list.size(); i++)

                    System.out.println(String.valueOf(i + 1) + ". Id-ul persoanei: " + list.get(i).getIdPersoana());


                System.out.println("Doriti sa notificati competitorii ?\n 1 penru DA 0 pentru NU");

                response = s.nextLine();

                if (response .equals("1")) {

                    String send = "NOTIF" + "#" + id_etapa;

                    for (int i = 0;i<list.size();i++)
                        send =send+"#"+list.get(i).getIdPersoana();


                    out.println(send);

                    System.out.println("PARTICIPANTI NOTIFICATI!");

                }
            }


        }
        }

}
