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
   
   
   
   
   
   

6. 
