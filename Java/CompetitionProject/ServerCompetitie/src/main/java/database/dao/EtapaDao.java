package database.dao;

import database.DatabaseConnection;
import entity.EtapaEntity;
import entity.ParticipantEntity;
import entity.PersoanaEntity;

import javax.persistence.TypedQuery;
import java.util.List;

public class EtapaDao implements DaoI<EtapaEntity>{

    DatabaseConnection connection = new DatabaseConnection();

    @Override
    public EtapaEntity get(int id) {
        return connection.getEntityManager().find(EtapaEntity.class, id );
    }

    @Override
    public List<EtapaEntity> getAll() {
        TypedQuery<EtapaEntity> query= connection.getEntityManager().createQuery("SELECT a FROM EtapaEntity a",EtapaEntity.class);
        return query.getResultList();
    }

    @Override
    public void create(EtapaEntity etapaEntity) {
        connection.executeTransaction(entityManager -> entityManager.persist(etapaEntity));
    }

    @Override
    public boolean del(int id) {
        EtapaEntity etapaEntity = this.get(id);
        return connection.executeTransaction(entityManager -> entityManager.remove(etapaEntity));
    }

    public boolean updateEtapa(EtapaEntity etapaEntity)
    {
        return connection.executeTransaction(entityManager -> etapaEntity.getClass());

    }
}
