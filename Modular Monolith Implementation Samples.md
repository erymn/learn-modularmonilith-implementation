# Modular Monolith Implementation Samples

1. Create an empty solution
   
   ```powershell
   dotnet new sln HazPro.ModularMonolith.Samples
   ```

2. Create Host Web Minimal API Project
   
   Web minimal API Project ini akan berfungsi sebagai host untuk aplikasi-aplikasi lainnya
   
   ```powershell
   dotnet new web -o HazPro.Host
   ```
   
   ```powershell
   dotnet sln HazPro.ModularMonolith.Samples.sln add ./HazPro.MM.Host/HazPro.MM.Host.csproj
   ```

3. Create Module Class Libraries (Payroll, Marketing, HR)
   
   ```powershell
   dotnet new classlib -o HazPro.Payroll
   dotnet new classlib -o HazPro.Marketing
   dotnet new classlib -o HazPro.HR
   
   dotnet sln HazPro.ModularMonolith.Samples.sln add ./HazPro.Payroll/HazPro.Payroll.csproj
   dotnet sln HazPro.ModularMonolith.Samples.sln add ./HazPro.Marketing/HazPro.Marketing.csproj
   dotnet sln HazPro.ModularMonolith.Samples.sln add ./HazPro.HR/HazPro.HR.csproj
   ```

4. Add framework reference di setiap module class library
   
   module yang akan ditambahkan adalah `Microsoft.AspNetCore.App`.
   
   Tambahkan reference diatas pada setiap .csproj yang ada di module class library.
   
   ```xml
   <ItemGroup>
       <FrameworkReference Include="Microsoft.AspNetCore.App"/>
   </ItemGroup>
   ```
   
   atau kalau menggunakan .Net CLI
   
   ```powershell
   dotnet add ./HazPro.HR/HazPro.HR.csproj framework-reference Microsoft.AspNetCore.App
   ```
   
   ```powershell
   dotnet add ./HazPro.Payroll/HazPro.Payroll.csproj framework-reference Microsoft.AspNetCore.App
   ```
   
   ```powershell
   dotnet add ./HazPro.Marketing/HazPro.Marketing.csproj framework-reference Microsoft.AspNetCore.App
   ```

5. Create Entity Classes
   
   ![](assets/2026-02-11-16-38-48-{27F9863D-089E-47A1-B5DA-B18340D22599}.png)
   
   ![](assets/2026-02-11-16-39-01-{8538D973-0A6A-4265-ADF1-3BFA1D0B6588}.png)
   
   ![](assets/2026-02-11-16-39-15-{4C546E76-9FED-4F3A-9439-8AF701C78099}.png)

6. Defining Module Endpoints
   
   ![](assets/2026-02-11-16-55-22-{40D0DEBC-2BC3-447A-87A0-24212FF87E8F}.png)
   
   ![](assets/2026-02-11-17-23-07-{FC7AA504-4FC4-4316-9DFE-699961297A46}.png)
   
   ![](assets/2026-02-11-17-23-19-{BF8E0225-80D3-4045-AFB7-750306944C18}.png)

7. Integrating Modules in Host App
   
   - Add Service Registration in each module
     
     ![](assets/2026-02-11-17-35-04-{335B0D35-4AA0-4E0F-B8C8-93E6ACE498F6}.png)
     
     ![](assets/2026-02-11-17-37-36-{0055DA61-5687-428F-9CBF-42E67661E2A7}.png)
     
     ![](assets/2026-02-11-17-41-18-{FB9BC6DC-3E51-4730-A14E-42E586E22831}.png)
   
   - Register Module Service in the Host App
     
     ![](assets/2026-02-11-17-44-29-{84D4387C-1241-4747-97CE-90C6972FD742}.png)
   
   - Map the Endpoints for each module
     
     ![](assets/2026-02-11-17-49-01-{DB7BBCE5-40DD-40BD-9D60-21BAAEEC4A40}.png)
   
   - Add http file in solution to test the code
     
     ![](assets/2026-02-12-10-43-05-{0DD93940-3759-4AF8-82EC-B7C38AB65E7C}.png)

8. Enhancing API with FastEndpoints
   
   ```powershell
   dotnet add HazPro.MM.Host package FastEndpoints
   ```
   
   ```powershell
   dotnet add HazPro.HR package FastEndpoints
   ```
   
   ```powershell
   dotnet add HazPro.Marketing package FastEndpoints
   ```
   
   ```powershell
   dotnet add HazPro.Payroll package FastEndpoints
   ```
   
   atau bisa dari Manage Nuget di Visual Studio atau Rider
   
   ![](assets/2026-02-12-10-55-57-{C4DC39A6-0CF0-466B-B8EA-CBCAA72C6F9E}.png)
   
   Create new Endpoint for FastEndpoints implementation
   
   ![](assets/2026-02-12-13-54-15-{348402F3-DA7E-4FFE-A035-9CD8CCD9010D}.png)
   
   ![](assets/2026-02-12-13-54-29-{18761BF3-9407-493A-8FC1-D55D4451DD33}.png)
   
   ![](assets/2026-02-12-13-54-41-{72D201E4-4EC0-46BA-AA46-57F0154CB58C}.png)

9. Configure FastEndpoints in Host Application
   
   ![](assets/2026-02-12-14-00-44-{E4E23BD2-4C24-43B0-9308-34AA470119AD}.png)

10. Modeling Entities and Separating DTO's
    
    The key reason:
    
    - `Separation of concern`, entity mewakili core bisnis domain model. DTO didesign untuk data transfer antar layer
    
    - `Flexibility & Evolution`, entity mungkin memiliki perbedaan dengan DTO. Perubahan dari cara present data seharusnya tidak mempengaruhi core bisnis
    
    - `Data Integrity & Encapsulation`, Entity bisa memiliki logic bisnis dan rule validasi. Dengan tetap memisahkannya dari DTO, kita bisa memastikan bahwa rule akan konsisten terhadap data kita. DTO biasanya secara struktur lebih simple dan fokus pada data transport
    
    Step to modeling entities
    
    - Rename set; entity into private set;
      
      ![](assets/2026-02-12-16-26-00-{4BDB8B22-A67B-4A35-9CBA-7F89DE75ED27}.png)
      
      Add new constructor and update method:
      
      ![](assets/2026-02-12-16-30-57-{956CCB57-3B1A-4C7A-8E32-FC7FE3F10392}.png)
    
    - Add library GuardClauses
      
      ![](assets/2026-02-12-16-36-01-{294BDA4E-E174-4D5C-BF16-84CACB85BB92}.png)
      
      and add validation rules into entity (Enforcing Business rule)
      
      ![](assets/2026-02-12-16-43-49-{A8EFD616-80B8-48DC-901C-080DAC72EA4B}.png)

11. Defining Repository Interface
    
    ![](assets/2026-02-12-17-06-38-{AF27DAAE-6327-4D8E-B623-E40F7EF81D98}.png)
    
    ![](assets/2026-02-12-17-07-05-{00428631-3A4B-4E52-8885-7658CA3CD63A}.png)
    
    ![](assets/2026-02-12-17-07-19-{C9E0521D-8B9F-4920-A9FB-B2B41A50A80D}.png)

12. Updating Service Classes to use Repositories
    
    ![](assets/2026-02-13-09-55-48-image.png)

13. Integrating with EF Core (menggunakan SQLite Database)
    
    Package yang harus diinstall:
    
    Install di project HR:
    
    ```powershell
    dotnet add package Microsoft.EntityFrameworkCore.SQLite
    dotnet add package Microsoft.EntityFrameworkCore
    ```
    
    Install di Host App:
    
    ```powershell
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```
    
    Tambahkan connection strings ke appsettings.json di Host App
    
    ```json
    "ConnectionStrings": {
        "HazProHRConnection": "Data Source=HazProHR.db"
      }
    ```
    
    Jika Payroll dan Marketing mau ditambahkan, maka gunakan nama lain dan database lain.
    
    **Create Context Class**
    
    ![](assets/2026-02-13-14-22-35-{CC19AD51-A1A1-43C3-BF62-2854BD5B7E18}.png)
    
    Untuk Apply setiap table yang digunakan, maka lebih baik dipisahkan pada suatu folder Configuration seperti pada gambar agar lebih manageable.
    
    ![](assets/2026-02-13-14-27-16-{40309A46-8158-48C7-A1F2-8284F7C96FBD}.png)
    
    lalu kemudian panggil dari AppDbContext class
    
    ![](assets/2026-02-13-14-28-55-{42DC27E8-50A7-4D31-9EA2-8E7869A1FF12}.png)
    
    **Registering the Repository, the Service and the DbContext**
    
    Registering database service ke HRExtensions
    
    ![](assets/2026-02-13-14-42-36-{7C217FDF-3AC7-417B-88EA-580E5EF9EC17}.png)
    
    **Creating Seed Data**
    
    Untuk membuat data, bisa menggunakan builder di configuration dan menggunakan metode `HasData`.
    
    ![](assets/2026-02-13-14-49-08-{6BD8EB63-E241-4100-A52F-002198605485}.png)
    
    **Create migrations and update database**
    
    Create the migrations
    
    ![](assets/2026-02-13-14-51-18-{5F76BD07-8A7A-44ED-8FF8-CE17B57CC997}.png)
    
    pastikan jalan di host project
    
    ```powershell
    dotnet ef migrations add Initial --context AppDbContext --project ..\HazPro.HR\HazPro.HR.csproj --startup-project .\HazPro.MM.Host\HazPro.MM.Host.csproj --output-dir Data/Migrat
    
    atau gunakan ini
    
    dotnet ef migrations add InitialCreate --context AppDbContext --project ..\HazPro.HR --startup-project .
    ```

14. Update the database
    
    ```powershell
    dotnet ef database update
    ```
    
    ![](assets/2026-02-13-16-43-06-{79262466-8CCC-46EB-BB2A-650846D8A2BB}.png)
    
    ![](assets/2026-02-13-16-43-19-{FC949CCA-11C4-4018-B3A4-FD597F53D726}.png)

15. Creating Repository to Interact with dbcontext
    
    ![](assets/2026-02-13-17-15-42-{903F0B35-34BB-4528-A3AD-CC09447A56BE}.png)

16. Implement CQRS and MediatR
    
    ```powershell
    dotnet add package MediatR
    dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
    ```
    
    Register MediatR di class extensions (HRExtensions sebagai contohnya):
    
    ```csharp
    services.AddMediatR(typeof(HRServicesExtensions).Assembly);
    ```
    
    ![](assets/2026-02-18-14-50-47-{6985BDEE-FD07-4EF3-9BC0-38C04331BA02}.png)
    
    **Create a Query Record**
    
    Digunakan untuk mewakili sebuah query yang akan mengambil Employee By ID
    
    ![](assets/2026-02-18-14-54-31-{A7495043-5018-448E-8A66-C8A538CCEA41}.png) 
    
    Akan dibuat record query yang akan mengambil informasi Employee By Id dan akan mengembalikan dalam bentuk EmployeeDto
    
    **Create Query Handler**
    
    Yang akan bertanggungjawab untuk mengisi record GetEmployeeByIdQuery. Handler ini akan menggunakan EF Core untuk fetch data dari database.
    
    ![](assets/2026-02-18-14-59-43-{C2693F2A-33CE-47FF-92C9-A58D7DE51CC8}.png)
    
    ![](assets/2026-02-18-15-02-43-{2A8D0619-809C-4CC2-8695-2C864DD2BFBD}.png)
    
    **Updating the GetEmployeeById Endpoint**
    
    update endpoint dengan menggunakan MediatR daripada langsung dengan memanggil service.
    
    Endpoint sebelum diubah ke MediatR
    
    ![](assets/2026-02-18-15-04-47-{03D3F116-5D10-4849-9E0E-1027101D4271}.png)
    
    Setelah diubah ke MediatR
    
    Ubah di constructor dulu, dari `IEmployeeServices `menjadi IMediatR 
    
    ![](assets/2026-02-18-15-07-48-{60FD851F-F646-42C6-9913-32CDAB8ED7B5}.png)
    
    Ubah di HandleAsync
    
    ![](assets/2026-02-18-15-10-55-{C7F05449-B5BB-4200-B064-D8191CBE6E2C}.png)
    
    Creating a New Employee with a Command
    
    ![](assets/2026-02-18-15-14-17-{9E1EA482-CE7C-499A-82FA-E66418F3980A}.png)
    
    Create Handler
    
    ![](assets/2026-02-18-15-57-24-{9BB94316-DF70-4148-B891-13C94B8C0510}.png)
    
    ![](assets/2026-02-18-16-21-34-{673B0D72-9BE2-4881-A295-7E277A6B3AC4}.png)
    
    

17. 
