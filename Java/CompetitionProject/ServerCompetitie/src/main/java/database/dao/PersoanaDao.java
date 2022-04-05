package database.dao;

import entity.PersoanaEntity;
import database.DatabaseConnection;

import javax.persistence.TypedQuery;
import java.util.List;


public class PersoanaDao implements DaoI<PersoanaEntity> {

 DatabaseConnection connection = new DatabaseConnection();

 @Override
 public PersoanaEntity get(int id) {
  return connection.getEntityManager().find(PersoanaEntity.class, id);
 }

 @Override
 public List<PersoanaEntity> getAll() {
  TypedQuery<PersoanaEntity> query = connection.getEntityManager().createQuery("SELECT a FROM PersoanaEntity a", PersoanaEntity.class);
  return query.getResultList();

 }

 @Override
 public boolean del(int id) {

  PersoanaEntity persoanaEntity = this.get(id);
  return connection.executeTransaction(entityManager -> entityManager.remove(persoanaEntity));


 }

 @Override
 public void create(PersoanaEntity persoanaEntity) {
  connection.executeTransaction(entityManager -> entityManager.persist(persoanaEntity));

 }


 public PersoanaEntity getByUser(String username) {
  TypedQuery<PersoanaEntity> query = connection.getEntityManager().createQuery("SELECT a FROM PersoanaEntity a where a.username=:username", PersoanaEntity.class)
          .setParameter("username", username);


  List<PersoanaEntity> list = query.getResultList();

  if (list.isEmpty() == false)

   return list.get(0);

  else return null;

 }

 public boolean updatePers(PersoanaEntity persoanaEntity) {
  return connection.executeTransaction(entityManager -> persoanaEntity.getClass());

 }

 public List<PersoanaEntity> getClasament() {
  TypedQuery<PersoanaEntity> query = connection.getEntityManager().createQuery("SELECT a FROM PersoanaEntity a where a.rol='competitor' ORDER BY a.punctaj desc", PersoanaEntity.class);


  List<PersoanaEntity> list = query.getResultList();
  if (list.size() == 0)
   return null;
  return list;

 }
 public List< PersoanaEntity> getEchipa(int id_echipa) {
  TypedQuery<PersoanaEntity> query = connection.getEntityManager().createQuery("SELECT a FROM PersoanaEntity a where a.idEchipa=:id_echipa", PersoanaEntity.class)
          .setParameter("id_echipa", id_echipa);


  List<PersoanaEntity> list = query.getResultList();

  if (list.isEmpty() == false)

   return list;

  else return null;

 }

}