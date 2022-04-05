package Functii;

import database.dao.EtapaDao;
import database.dao.ParticipantDao;
import database.dao.PersoanaDao;
import entity.EtapaEntity;
import entity.ParticipantEntity;
import entity.PersoanaEntity;

import javax.persistence.criteria.CriteriaBuilder;
import java.util.ArrayList;
import java.util.List;

public class Functii {

    public static void updatePunctaje(int id_etapa)
    {
        ParticipantDao participantDao = new ParticipantDao();

        List<ParticipantEntity> list= participantDao.getPartFaraScor(id_etapa);

        EtapaDao etapaDao = new EtapaDao();

        if(list==null)
        {   System.out.println("updated punctaje pt etapa "+id_etapa);

            EtapaEntity etapaEntity= etapaDao.get(id_etapa);

            etapaEntity.setIncheiata(true);

            etapaDao.updateEtapa(etapaEntity);

            PersoanaDao persoanaDao = new PersoanaDao();


            List<ParticipantEntity> clasament = participantDao.getPartOrdonati(id_etapa);

//
//            List<Integer> punctaje= new ArrayList<Integer>() ;
//            punctaje.add(10);
//            punctaje.add(6);
//            punctaje.add(4);
//            punctaje.add(1);

            int index=0;
            int nrGrupe=1;
            int punctaj=10;
            int scadere=4;
            while (index!=3&&index!=clasament.size())
            {
                PersoanaEntity pers= persoanaDao.get(clasament.get(index).getIdPersoana());
                pers.setPunctaj(pers.getPunctaj()+punctaj);
                persoanaDao.updatePers(pers);

                punctaj-=scadere;
                scadere--;
                index++;
            }




        }

    }
}
