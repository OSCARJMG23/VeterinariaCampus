# VeterinariaCampus

## Consultas
- Para realizar las consultas primero ejecutar el comando: dotnet ef database update --project .\Persistencia\ --startup-project .\ApiVet\

 * Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.
   - Endpoint de consulta: http://localhost:5078/api/Veterinario/cirujano-vascular
    Respuesta
    ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/21a9797f-db47-4ed4-a297-3f0f9a74f8bf)

  * Listar los medicamentos que pertenezcan a el laboratorio Genfar
    - Endpoint de consulta: http://localhost:5078/api/Medicamento/laboratorio-genfar
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/17b9fb0e-f7f2-4c8b-8c97-f8999a9d0d2a)
  
  * Mostrar las mascotas que se encuentren registradas cuya especie sea felina.
    - Endpoint de consulta: http://localhost:5078/api/Mascota/especie-felina
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/e81e45ed-2575-4239-a6b4-62059ec86c60)
  
  * Listar los propietarios y sus mascotas.
    - Endpoint de consulta: http://localhost:5078/api/Propietario/mascotas
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/ce83ab35-dd29-47f5-95f0-01e12eafcfa1)
  
  * Listar los medicamentos que tenga un precio de venta mayor a 50000
    - Endpoint de consulta: http://localhost:5078/api/Medicamento/precio-mayor-50k
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/ed3fd86e-78be-4191-bedb-61a82606c299)

  * Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023
    - Endpoint de consulta: http://localhost:5078/api/Mascota/cita-vacunacion-2023
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/e6f7156d-a725-427a-b85e-73bdc1c36892)
    
  * Listar todas las mascotas agrupadas por especie.
    - Endpoint de consulta: http://localhost:5078/api/Mascota/mascotaXespecie
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/5c73a329-d041-4afd-9080-2bf1f188aaf7)
      
  * Listar todos los movimientos de medicamentos y el valor total de cada movimiento.
    - Endpoint de consulta: http://localhost:5078/api/Movimiento/valorTotalXmovimientos
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/b75731b0-3e3f-42ac-b5ae-4b97b400c9da)

  * Listar las mascotas que fueron atendidas por un determinado veterinario.
    - Endpoint de consulta: http://localhost:5078/api/Mascota/mascota-atendidaXveterinario/Dr. Juan Pérez
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/40917cbf-393d-45a3-9e22-f8933c278fe9)

  * Listar los proveedores que me venden un determinado medicamento.
    - Endpoint de consulta: http://localhost:5078/api/Proveedor/con/PetRelief
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/3cc63e48-6bca-47a6-bf37-8d8a2c6c7ebd)
 
  * Listar las mascotas y sus propietarios cuya raza sea Golden Retriver
    - Endpoint de consulta: http://localhost:5078/api/Mascota/mascota-Y-propietario-goldenRetriever
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/3b3c5811-3445-4531-bf6c-2c2ab8d33fd0)

  * Listar la cantidad de mascotas que pertenecen a una raza a una raza. Nota: Se debe mostrar una lista de las razas y la cantidad de mascotas que pertenecen a la raza.
    - Endpoint de consulta: http://localhost:5078/api/Raza/cantidad-mascotasXraza
      Respuesta
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/ce9dc46c-19b2-44fd-90e8-cef41a860a31)

  * El versionado se usa en los metodos Get de la version 1.1 donde se listan las respuestas de manera normal (Sin paginacion)
    - Sin versionado los Get se muestran de la siguiente manera:
      
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/663f79bf-9b7b-43bd-8290-0bce840d8444)

    - Y con versionado usando: http://localhost:5078/api/laboratorio?ver=1.1
      Se muestra de la siguiente manera
      
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/522de03b-467a-473b-88f0-b16b544e0b39)

  * Endpoints relacionados con jwt:
    - Register: http://localhost:5078/api/user/register
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/23a95a3a-e856-41fe-8d2f-717ed6dd3931)

    - Add Rol: http://localhost:5078/api/user/addrole
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/6c2bcf00-406d-425e-8a8a-b2d91f96971c)

    - Token: http://localhost:5078/api/user/token
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/fa80a791-24e0-42bc-8f6e-f86baa032b3d)

    - Refresh Token: http://localhost:5078/api/user/refresh-token
      ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/fce0005e-29d6-430f-976b-98892f9be409)

      * Nota: Para probar el funcionamiento de JWT si es necesario realizar el proceso de registrar, ya que no incluyo usuarios para el llenado de las tablas.
      * Nota 2: Para el paginado de Citas, Movimientos y Tratamientos medicos, para la consulta por query las manejé mediante el Id, ejemplo: http://localhost:5078/api/tratamientomedico?search=1
     
        ![image](https://github.com/OSCARJMG23/VeterinariaCampus/assets/133609079/ec74e093-e748-42c4-92cc-51e6aebd0a92)

        





