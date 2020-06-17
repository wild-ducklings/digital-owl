### Add Entity Tips

#### Repo phase
1. Create Entity in Repository [syntax: <Name>].
2. Create Interface that inherits IGenericRepository with new Entity [syntax: I<Name>Repository].
3. Implement Repository. It must inherit GenericRepository with new Entity [syntax: <Name>Repository].
4. Update IUnitOfWork with access singleton.
5. Update UnitOfWork with private and public (with get method) instance of Interface. 
6. Update ApplicationDbContext in order to set a particular table in database.
7. Write unit test.
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
3. Write integration test.
