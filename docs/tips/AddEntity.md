### Add Entity Tips

#### Repo phase
1. Create Entity in Repository [syntax: <Name>].
2. IF relationship of the Entity is to MANY add model builder for entity to be on delete
   in ApplicationDbContext.
3. Create Interface that inherits IGenericRepository with new Entity [syntax: I<Name>Repository].
4. Implement Repository. It must inherit GenericRepository with new Entity [syntax: <Name>Repository].
5. Update IUnitOfWork with access singleton.
6. Update UnitOfWork with private and public (with get method) instance of Interface. 
7. Update ApplicationDbContext in order to set a particular table in database.
8. Write unit test.
#### Service phase
1. Create Dto model in Service [syntax: Dto<Name>].
2. Add map for AutoMapper in Infrastructure/DtoToEntityMapperProfile
3. Create Interface [syntax: I<Name>Service].
4. Implement Service. It must inherit BaseService [syntax: <Name>Service].
5. Register this new Service in Api/Startup/ServicesRegister
6. Write unit test.
#### Controller phase
1. Create Model in Api:
    - CreateModel and ValidateModel [syntax: Create<Name>, Validate<Name>].
2. Add map for AutoMapper in Infrastructure/ModelToDtoMapperProfile.
3. Implement Controller [syntax: <Name>Controller].
3. Write integration test.
