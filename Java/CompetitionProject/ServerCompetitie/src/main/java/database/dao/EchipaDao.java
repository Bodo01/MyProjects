package database.dao;

import database.DatabaseConnection;
import entity.EchipaEntity;
import entity.EtapaEntity;
import entity.ParticipantEntity;

import javax.persistence.TypedQuery;
import java.util.List;

public class EchipaDao implements DaoI<EchipaEntity>{

    DatabaseConnection connection = new DatabaseConnection();

    @Override
    public EchipaEntity get(int id) {
        return connection.getEntityManager().find(EchipaEntity.class, id );
    }

    @Override
    public List<EchipaEntity> getAll() {
        TypedQuery<EchipaEntity> query= connection.getEntityManager().createQuery("SELECT a FROM EchipaEntity a",EchipaEntity.class);
        return query.getResultList();
    }

    @Override
    public void create(EchipaEntity echipaEntity) {
        connection.executeTransaction(entityManager -> entityManager.persist(echipaEntity));
    }

    @Override
    public boolean del(int id) {
      EchipaEntity echipaEntity = this.get(id);
        return connection.executeTransaction(entityManager -> entityManager.remove(echipaEntity));


    }

    public boolean updateEchipa(EchipaEntity echipaEntity)
    {
        return connection.executeTransaction(entityManager -> echipaEntity.getClass());

    }
}
