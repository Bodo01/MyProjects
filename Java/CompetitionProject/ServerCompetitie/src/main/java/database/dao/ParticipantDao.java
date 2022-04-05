package database.dao;

import database.DatabaseConnection;
import entity.ParticipantEntity;
import entity.PersoanaEntity;

import javax.persistence.TypedQuery;
import java.util.List;

public class ParticipantDao implements DaoI<ParticipantEntity> {
    DatabaseConnection connection = new DatabaseConnection();

    @Override
    public ParticipantEntity get(int id) {
        return connection.getEntityManager().find(ParticipantEntity.class, id );
    }

    @Override
    public List<ParticipantEntity> getAll() {

        TypedQuery<ParticipantEntity> query= connection.getEntityManager().createQuery("SELECT a FROM ParticipantEntity a",ParticipantEntity.class);
        return query.getResultList();
    }

    @Override
    public void create(ParticipantEntity participantEntity) {
        connection.executeTransaction(entityManager -> entityManager.persist(participantEntity));
    }

    public ParticipantEntity getPart(int id_pers, int id_etapa)
    {
        TypedQuery<ParticipantEntity> query = connection.getEntityManager().createQuery("SELECT a FROM ParticipantEntity a where a.idPersoana=:id_pers and a.idEtapa=:id_etapa", ParticipantEntity.class)
                .setParameter("id_pers",id_pers).setParameter("id_etapa",id_etapa);


        List<ParticipantEntity> list = query.getResultList();

        if (list.isEmpty()==false)

            return list.get(0);

        else return null;

    }
    public List<ParticipantEntity> getPartFaraScor(int id_etapa)
    {
        TypedQuery<ParticipantEntity> query = connection.getEntityManager().createQuery("SELECT a FROM ParticipantEntity a where a.punctaj=-1 and a.idEtapa=:id_etapa", ParticipantEntity.class)
                .setParameter("id_etapa",id_etapa);


        List<ParticipantEntity> list = query.getResultList();
  if (list.size()==0)
      return null;
        return list;

    }

    public List<ParticipantEntity> getPartOrdonati(int id_etapa)
    {
        TypedQuery<ParticipantEntity> query = connection.getEntityManager().createQuery("SELECT a FROM ParticipantEntity a where a.idEtapa=:id_etapa ORDER BY a.punctaj desc", ParticipantEntity.class)
                .setParameter("id_etapa",id_etapa);


        List<ParticipantEntity> list = query.getResultList();
        if (list.size()==0)
            return null;
        return list;

    }

    public boolean updateScor(ParticipantEntity participantEntity)
    {
        return connection.executeTransaction(entityManager -> participantEntity.getClass());

    }


    @Override
    public boolean del(int id) {

       ParticipantEntity participantEntity= this.get(id);
        return connection.executeTransaction(entityManager -> entityManager.remove(participantEntity));
    }
}
