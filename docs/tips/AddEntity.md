### Add Entity Tips

#### Repo phase
1. Create Entity in Repository.
2. Create Interface that inherits IGenericRepository with new Entity.
3. Implement it. It inherits GenericRepository with new Entity.
4. Create unit test.
#### Service phase
1. Create Dto model in Service.
2. Add map for AutoMapper in Infrastructure/DtoToEntityMapperProfile
3. Create Interface.
4. Implement it. It inherits BaseService.
5. Register this new Service in Api/Startup/ServicesRegister
6. Create unit test.
#### Controller phase
1. Create Model in Api:
    - ViewModel, or/and
    - CreateModel and ValidationModel.
2. Add map for AutoMapper in Infrastructure/ModelToDtoMapperProfile.
3. Create integration test.
