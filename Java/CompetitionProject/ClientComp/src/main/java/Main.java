import Classes.Admin;
import Classes.Competitor;

import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws IOException {
        final String HOST = "localhost";
        final int PORT = 4040;


        Competitor competitor = null;
        Admin admin = null;

        String username;
        int id;
        boolean adminbool = false;

        Scanner s = new Scanner(System.in);
        Socket socket = new Socket(HOST, PORT);
        PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
        Scanner in = new Scanner(socket.getInputStream());

        System.out.println("Client started.");





            while (true) {

                System.out.print("Username: ");
                String input = s.nextLine();
                username = input;
                input = "LOGIN" + input;
                out.println(input);
                String response = in.nextLine();

                if (response.charAt(0) == '0') System.out.println("Login failed\n");
                else if (response.charAt(0) == '1') {
                    System.out.println("Logged in as competitor");
                    id = Integer.parseInt(response.substring(1));

                   // System.out.println(id);
                    competitor = new Competitor(id,username,s,socket,out,in);
                    break;
                } else {
                    System.out.println("Logged in as admin");
                    adminbool = true;
                    id = Integer.parseInt(response.substring(1));
                    competitor = new Competitor(id,username,s,socket,out,in);
                    admin = new Admin(id,username,s,socket,out,in);


                    System.out.println(id);
                    break;

                }

            }




        if (adminbool==false) {

            while (true) {
            System.out.println("\n\nIntroduceti:");

                System.out.println("1. Pentru inscriere intr-o etapa");
                System.out.println("2. Pentru inscriere scor intr-o etapa");
                System.out.println("3. Pentru afisare clasamente actuale");
                System.out.println("4. Pentru afisare clasament pe stage");
                System.out.println("5. Pentru notificari");
                System.out.println("0. Pentru a inchide programul");
                int x;

                x=Integer.parseInt(s.nextLine());


                switch (x){

                    case 0:
                        return;

                    case 1:
                        competitor.InscriereEtapa();
                        break;
                    case 2:
                        competitor.InscriereScor();
                        break;
                    case 3:
                        competitor.clasament();
                        break;
                    case 4:
                        competitor.clasamentPeStage();
                        break;
                    case 5:
                        competitor.notif();
                        break;
                   default :
                        System.out.println("Nicio optiune valabila selectata!");


                }

            }


        }else
        {
            while (true) {
                System.out.println("\n\nIntroduceti:");

                System.out.println("1. Adaugare etapa noua.");
                System.out.println("2. Creati/Vizualizati/Editati echipe.");
                System.out.println("3. Pentru afisare clasamente actuale.");
                System.out.println("4. Pentru afisare clasament pe stage.");
                System.out.println("5. Adagati o noua persoana in competitie.");
                System.out.println("6. Vizualizati participantii care nu si au inscris scorul la o etapa.");
                System.out.println("0. Pentru a inchide programul.");
                int x;

                x=Integer.parseInt(s.nextLine());


                switch (x){

                    case 0:
                        return;

                    case 1:
                        admin.etapaNoua();
                        break;
                    case 2:
                        admin.echipaNoua();
                        break;
                    case 3:
                        competitor.clasament();
                        break;
                    case 4:
                        competitor.clasamentPeStage();
                        break;
                    case 5:
                        admin.persNoua();
                        break;
                    case 6:
                        admin.partFaraScor();
                        break;
                    default :
                        System.out.println("Nicio optiune valabila selectata!");


                }

            }


        }


    }
}