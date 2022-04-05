package Classes;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.io.PrintWriter;
import java.lang.reflect.Type;
import java.net.Socket;
import java.util.*;


public class Competitor {

    private int id;
    private String username;
    private Socket socket;
    private PrintWriter out;
    private Scanner in;
    private Scanner s;

        public  Competitor(int id, String username, Scanner s, Socket socket, PrintWriter out, Scanner in) throws IOException {

           // final String HOST = "localhost";
          //  final int PORT = 4040;


            this.id=id;
            this.username=username;

            //  socket = new Socket (HOST,PORT);
            // out = new PrintWriter(socket.getOutputStream(), true);
            // in = new Scanner(socket.getInputStream());
            // s = new Scanner(System.in);
            this.socket=socket;
            this.out=out;
            this.in=in;
            this.s=s;



        }


        public void InscriereScor() throws IOException
        {

            out.println("ETAPE");

            String response = in.nextLine();

            ObjectMapper mapper = new ObjectMapper();

            List<Etapa> listaEtape = mapper.readValue(response, new TypeReference<List<Etapa>>() {});

            for (int i=0;i<listaEtape.size();i++)
            {
                System.out.println("Etapa id: " + listaEtape.get(i).getIdEtapa()+"  Denumire etapa: " +
                        listaEtape.get(i).getDenumire() + "  Incheiata: " + listaEtape.get(i).getIncheiata());


            }


            System.out.println("Introduceti id-ul etapei in care doriti sa introduceti scorul: ");
            String input="";

            input =s.nextLine();

            input = "SCORR" + input +"#";
                    System.out.println("Introduceti scorul: ");
             input += s.nextLine();

             input = input+"#"+String.valueOf(id);
             out.println(input);

             response = in.nextLine();

             if (response.equals("0"))
                 System.out.println("Nu sunteti inscris in aceasta etapa!");
             else  if (response.equals("1"))
                 System.out.println("Ati adaugat deja un scor acestei etape!");
             else if(response.equals("2"))System.out.println("Scor adaugat cu succes!");
             else System.out.println("Etapa selectata nu exista!");



        }
        public void InscriereEtapa()throws IOException
        {
            out.println("ETAPE");

            String response = in.nextLine();

            ObjectMapper mapper = new ObjectMapper();

            List<Etapa> listaEtape = mapper.readValue(response, new TypeReference<List<Etapa>>() {});

            for (int i=0;i<listaEtape.size();i++)
            {
                System.out.println("Etapa id: " + listaEtape.get(i).getIdEtapa()+"  Denumire etapa: " +
                        listaEtape.get(i).getDenumire() + "  Incheiata: " + listaEtape.get(i).getIncheiata());


            }

            System.out.println("Introduceti id-ul etapei in care doriti sa va inscrieti: ");
            String input="";
            input =s.nextLine();
            input = "INSCR"+input+"#"+String.valueOf(id);

            out.println(input);

            System.out.println(in.nextLine());

        }

    public void clasament()throws IOException
    {
        out.println("CLSMT");
        String response = in.nextLine();

        ObjectMapper mapper = new ObjectMapper();

        List<Persoana> clasament = mapper.readValue(response, new TypeReference<List<Persoana>>() {});

        System.out.println("CLASAMENT INDIVIDUAL:");
       if(clasament==null) System.out.println("Niciun competitor inscris!");
       else {
           for (int i = 0; i < clasament.size(); i++)

               System.out.println(String.valueOf(i + 1) + ". " + clasament.get(i).getNume() + " scor: " + clasament.get(i).getPunctaj());
           System.out.println("CLASAMENT PE ECHIPE:");

           Map<Integer, Integer> map = new HashMap<>();

           for (int i = 0; i < clasament.size(); i++) {
               int valueFound = map.getOrDefault(clasament.get(i).getIdEchipa(), -5);
               if (valueFound == -5)
                   map.put(clasament.get(i).getIdEchipa(), clasament.get(i).getPunctaj());
               else map.put(clasament.get(i).getIdEchipa(), valueFound + clasament.get(i).getPunctaj());
           }


           LinkedHashMap<Integer, Integer> sortedMap = new LinkedHashMap<>();

           map.entrySet()
                   .stream()
                   .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
                   .forEachOrdered(x -> sortedMap.put(x.getKey(), x.getValue()));


           Iterator iterator = sortedMap.keySet().iterator();

           int index = 1;
           while (iterator.hasNext()) {
               Object key = iterator.next();
               Object value = map.get(key);
               System.out.println(index + ". " + "Id echipa " + key + " scor  " + value);
               index++;
           }
       }
    }
    public void clasamentPeStage()throws IOException
    {
        out.println("ETAPE");

        String response = in.nextLine();

        ObjectMapper mapper = new ObjectMapper();

        List<Etapa> listaEtape = mapper.readValue(response, new TypeReference<List<Etapa>>() {});

        for (int i=0;i<listaEtape.size();i++)
        {
            System.out.println("Etapa id: " + listaEtape.get(i).getIdEtapa()+"  Denumire etapa: " +
                    listaEtape.get(i).getDenumire() + "  Incheiata: " + listaEtape.get(i).getIncheiata());


        }

        System.out.println("Introduceti id ul etapei al carui clasament doriti sa il vedeti: ");

        int id_etapa;

        id_etapa=Integer.parseInt(s.nextLine());

        boolean found=false;

        for (int i =0;i<listaEtape.size();i++)
            if (listaEtape.get(i).getIdEtapa()==id_etapa) found=true;


        if (found==false) System.out.println("Id etapa invalid");
        else
        {
        out.println("CLSST"+String.valueOf( id_etapa));
        response = in.nextLine();




        List<Participant> clasament = mapper.readValue(response, new TypeReference<List<Participant>>() {});

        if (clasament==null) System.out.println("Nu exista participanti in etapa selectata!");
        else

        for (int i=0;i<clasament.size();i++)

            System.out.println(String.valueOf(i+1)+". Id-ul persoanei: "+clasament.get(i).getIdPersoana()+" scor: " +clasament.get(i).getPunctaj());

        }
    }

    public void notif() throws IOException{

            out.println("MYNOT"+String.valueOf(id));

            System.out.println(in.nextLine());


    }
}
