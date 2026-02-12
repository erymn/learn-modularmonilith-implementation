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
8. 
