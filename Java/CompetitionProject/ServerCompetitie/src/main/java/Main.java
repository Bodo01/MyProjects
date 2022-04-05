import com.fasterxml.jackson.databind.ObjectMapper;
import database.dao.EchipaDao;
import database.dao.EtapaDao;
import database.dao.ParticipantDao;
import database.dao.PersoanaDao;
import entity.EchipaEntity;
import entity.EtapaEntity;
import entity.ParticipantEntity;
import entity.PersoanaEntity;

import java.io.IOException;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import Functii.Functii;

public class Main {





    public static void main(String[] args) throws IOException {


        Map<Integer,String> notification = new HashMap<Integer,String >();

        final int PORT = 4040;
        ServerSocket serverSocket = new ServerSocket(PORT);

        System.out.println("Server started...");
        System.out.println("Wating for clients...");

        while (true) {
            Socket clientSocket = serverSocket.accept();
            Thread t = new Thread() {
                public void run() {
                    try (
                            PrintWriter out = new PrintWriter(clientSocket.getOutputStream(), true);
                            Scanner in = new Scanner(clientSocket.getInputStream());
                    ) {
                        while (in.hasNextLine()) {
                            String input = in.nextLine();

                            String action= input.substring(0,5);




                             if (action.equals("LOGIN"))
                            {



                                PersoanaDao persoanaDao = new PersoanaDao();

                                PersoanaEntity persoanaEntity= persoanaDao.getByUser(input.substring(5));



                                if (persoanaEntity == null)
                                    out.println("0");
                                else if (persoanaEntity.getRol().equals("admin"))
                                    out.println("2"+String.valueOf(persoanaEntity.getIdPersoana()));
                                else  out.println("1"+String.valueOf(persoanaEntity.getIdPersoana()));


                            }
                                else
                                    if (action.equals("ETAPE"))
                                    {
                                        EtapaDao etapaDao= new EtapaDao();

                                        List<EtapaEntity> listEtapa= etapaDao.getAll();

                                        ObjectMapper mapper = new ObjectMapper();

                                        String jsonString = "";
                                        jsonString = mapper.writeValueAsString(listEtapa);
                                        out.println(jsonString);

                                    }
                                    else if (action.equals("SCORR"))
                                    {
                                        input = input.substring(5);
                                        int idEtapa=0;

                                        int id_pers=0;
                                        int index=0;
                                        while (Character.isDigit(input.charAt(index)))
                                            index++;

                                        idEtapa =Integer.parseInt(input.substring(0,index));

                                        int index2 =++index;
                                        while (Character.isDigit(input.charAt(index2)))
                                            index2++;

                                        int scor=Integer.parseInt(input.substring(index,index2));

                                        id_pers=Integer.parseInt(input.substring(index2+1));

                                        ParticipantDao participantDao = new ParticipantDao();


                                        //System.out.println(idEtapa+" "+scor+" "+id_pers);

                                        ParticipantEntity participantEntity= participantDao.getPart(id_pers,idEtapa);

                                        EtapaDao etapaDao = new EtapaDao();

                                        EtapaEntity etapaEntity = etapaDao.get(idEtapa);

                                        if(etapaEntity==null) out.println("3");
                                        else
                                        if (participantEntity==null) out.println("0");
                                            else
                                                if (participantEntity.getPunctaj()!=-1)
                                                    out.println("1");
                                                else{
                                                    participantEntity.setPunctaj(scor);
                                                    participantDao.updateScor(participantEntity);
                                                    out.println("2");

                                                    Functii.updatePunctaje(idEtapa);//verifica daca scorul introdus a fost ultimul scor care trebuia introdus si marcheaza etapa ca incheiata
                                                }




                                    }
                                    else if (action.equals("INSCR"))
                                    {
                                        input = input.substring(5);
                                        int idEtapa=0;

                                        int id_pers=0;
                                        int index=0;
                                        while (Character.isDigit(input.charAt(index)))
                                            index++;

                                        idEtapa =Integer.parseInt(input.substring(0,index));

                                        id_pers=Integer.parseInt(input.substring(index+1));

                                        ParticipantDao participantDao = new ParticipantDao();


                                        //System.out.println(idEtapa+" "+scor+" "+id_pers);

                                        ParticipantEntity participantEntity= participantDao.getPart(id_pers,idEtapa);





                                        if (participantEntity==null)
                                        {
                                            EtapaDao etapaDao = new EtapaDao();

                                            EtapaEntity etapaEntity= etapaDao.get(idEtapa);

                                            if (etapaEntity!=null)
                                            {if (etapaEntity.getIncheiata()==true)  out.println("ETAPA INCHEIATA DEJA!");
                                             else{ ParticipantEntity participantEntity1 = new ParticipantEntity();

                                            participantEntity1.setIdEtapa(idEtapa);
                                            participantEntity1.setIdPersoana(id_pers);
                                            participantEntity1.setPunctaj(-1);

                                            participantDao.create(participantEntity1);

                                            out.println("INSCRIS CU SUCCES!");}}
                                            else out.println("ETAPA NU EXISTA");
                                        }else
                                        {
                                            out.println("DEJA INSCRIS!");

                                        }


                                    }
                                    else if (action.equals("CLSMT")) //clasament final
                                    {
                                        PersoanaDao persoanaDao = new PersoanaDao();

                                        List<PersoanaEntity> clasament= persoanaDao.getClasament();

                                        ObjectMapper mapper = new ObjectMapper();

                                        String jsonString = "";
                                        jsonString = mapper.writeValueAsString(clasament);
                                        out.println(jsonString);
                                    }
                                    else if (action.equals("CLSST")) //clasament pe stage
                                    {


                                        ParticipantDao participantDao = new ParticipantDao();

                                        List<ParticipantEntity> clasament= participantDao.getPartOrdonati(Integer.parseInt(input.substring(5)));

                                        ObjectMapper mapper = new ObjectMapper();

                                        String jsonString = "";
                                        jsonString = mapper.writeValueAsString(clasament);
                                        out.println(jsonString);

                                    }
                                    else if (action.equals("NOUET"))
                                    {
                                        EtapaDao etapaDao = new EtapaDao();
                                        EtapaEntity etapaEntity = new EtapaEntity();

                                        etapaEntity.setIncheiata(false);
                                        etapaEntity.setDenumire(input.substring(5));

                                        etapaDao.create(etapaEntity);

                                        out.println("ETAPA CREATA CU SUCCES");

                                    }
                                    else
                                    if (action.equals("ECHIP"))
                                    {
                                        EchipaDao echipaDao= new EchipaDao();

                                        List<EchipaEntity> listEchipa= echipaDao.getAll();

                                        ObjectMapper mapper = new ObjectMapper();

                                        String jsonString = "";
                                        jsonString = mapper.writeValueAsString(listEchipa);
                                        out.println(jsonString);

                                    } else if (action.equals("NOUEC"))
                                    {
                                        EchipaDao echipaDao = new EchipaDao();
                                        EchipaEntity echipaEntity = new EchipaEntity();

                                        echipaEntity.setNumeEchipa(input.substring(5));


                                        echipaDao.create(echipaEntity);

                                        out.println("ECHIPA CREATA CU SUCCES");

                                    }
                                    else if (action.equals("NOUPE"))
                                    {
                                        input=input.substring(5);

                                        String[] parts = input.split("#");
                                        String id_echipa = parts[1];
                                        String nume = parts[2];
                                        String username= parts[3];

                                       // System.out.println("parts 0 :"+parts[1]+"parts 1: " + parts[2]+ "parts 2: "+parts[3]);

                                        PersoanaDao persoanaDao = new PersoanaDao();
                                        EchipaDao echipaDao = new EchipaDao();
                                        EchipaEntity echipaEntity = echipaDao.get(Integer.parseInt(id_echipa));

                                        if (persoanaDao.getByUser(username)!=null) out.println("USERNAME-UL DEJA EXISTA!");
                                        else
                                        if (echipaEntity==null) out.println("ECHIPA NU EXISTA!");
                                        else {

                                            List<PersoanaEntity> listPers = persoanaDao.getEchipa(Integer.parseInt(id_echipa));

                                            boolean ok=true;

                                            if (listPers!=null)
                                                if (listPers.size()>=5)
                                                {out.println("ECHIPA ESTE PLINA!");
                                                     ok=false;}

                                            if (ok)
                                            {
                                                PersoanaEntity persoanaEntity = new PersoanaEntity();
                                                persoanaEntity.setIdEchipa(Integer.parseInt(id_echipa));
                                                persoanaEntity.setUsername(username);
                                                persoanaEntity.setRol("competitor");
                                                persoanaEntity.setNume(nume);
                                                persoanaEntity.setPunctaj(0);

                                                persoanaDao.create(persoanaEntity);

                                                out.println("PERSOANA ADAUGATA CU SUCCES!");


                                            }

                                        }

                                    }
                                    else if (action.equals("UPDEC")){

                                        input=input.substring(5);

                                        String[] parts = input.split("#");
                                        String id_echipa = parts[1];
                                        String nume_echipa = parts[2];

                                        EchipaDao echipaDao = new EchipaDao();

                                        EchipaEntity echipaEntity= echipaDao.get(Integer.parseInt( id_echipa));

                                        if (echipaEntity==null) out.println("ID DE ECHIPA INVALID");
                                            else
                                                echipaEntity.setNumeEchipa(nume_echipa);
                                                echipaDao.updateEchipa(echipaEntity);
                                                out.println("ECHIPA MODIFICATA CU SUCCES");


                                    }
                                    else if (action.equals("FARAS")) {
                                    int id_etapa= Integer.parseInt(input.substring(5));

                                        EtapaDao etapaDao = new EtapaDao();
                                        EtapaEntity etapaEntity = etapaDao.get(id_etapa);

                                        if (etapaEntity==null)
                                            out.println("ID ETAPA INVALID!");
                                        else
                                        {
                                            ParticipantDao participantDao = new ParticipantDao();
                                            List<ParticipantEntity> listPart= participantDao.getPartFaraScor(id_etapa);

                                            if (listPart==null)
                                                out.println("NU EXISTA PARTICIPANTI FARA SCOR IN ETAPA SELECTATA");
                                            else
                                            {
                                                ObjectMapper mapper = new ObjectMapper();

                                                String jsonString = "";
                                                jsonString = mapper.writeValueAsString(listPart);
                                                out.println(jsonString);

                                            }
                                        }

                                    }
                                    else if (action.equals("NOTIF"))
                                    {
                                        input=input.substring(5);

                                        String[] parts = input.split("#");

                                        String id_etapa= parts[1];

                                        for (int i=2;i<parts.length;i++)
                                        {
                                            String id=parts[i];
                                            notification.put(Integer.parseInt(id),"Admin Message:Va rog sa inscrieti scorul pentru etapa "+id_etapa);
                                        }

                                    }
                                    else if (action.equals("MYNOT"))
                                    {

                                        if (notification.get(Integer.parseInt(input.substring(5)))==null)
                                            out.println("NU AVETI NOTIFICARI!");
                                        else out.println(notification.get(Integer.parseInt(input.substring(5))));

                                    }
                        }
                    } catch (IOException e) { }
                }
            };
            t.start();
        }
  }
}
