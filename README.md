<h1 style="text-align: center; font-family: Arial, sans-serif; color: #2c3e50;">
    🚀 Application Tracker API
</h1>

<p style="font-size: 18px; color: #34495e; text-align: center;">
    A RESTful API for managing project applications, statuses, and inquiries.
</p>

<h2 style="color: #2980b9;">✨ Features</h2>
<ul style="font-size: 16px; color: #2c3e50;">
    <li>📌 <strong>CRUD operations for applications</strong></li>
    <li>📩 <strong>Inquiry management with tracking</strong></li>
    <li>📊 <strong>Database integration with Entity Framework</strong></li>
</ul>

<h2 style="color: #27ae60;">⚙️ Technologies</h2>
<ul style="font-size: 16px; color: #2c3e50;">
    <li>🌐 <strong>ASP.NET Core Web API</strong></li>
    <li>🗄️ <strong>Entity Framework Core (EF Core)</strong></li>
    <li>🛠️ <strong>SQL Server</strong></li>
</ul>

<h2 style="color: #2ecc71;">🔧 Architecture & Tools</h2>
<ul style="font-size: 16px; color: #2c3e50;">
    <li>🛠 <strong>Dependency Injection</strong> - Loose coupling for better maintainability</li>
    <li>📝 <strong>Swagger (OpenAPI)</strong> - API documentation & testing</li>
    <li>📦 <strong>Repository Pattern</strong> - Clean data access separation</li>
</ul>


<h2 style="color: #8e44ad;">📦 Installation</h2>
<pre style="background: #ecf0f1; padding: 10px; border-radius: 5px;">
<code>
git clone https://github.com/sezerturkdal/AppTrackerAPI.git
cd AppTrackerAPI
dotnet restore
dotnet run
</code>
</pre>

<h2 style="color: #d35400;">📡 API Endpoints</h2>
<table style="border-collapse: collapse; width: 100%; border: 1px solid #ddd;">
    <tr style="background: #f4f4f4;">
        <th style="padding: 10px; border: 1px solid #ddd;">Method</th>
        <th style="padding: 10px; border: 1px solid #ddd;">Endpoint</th>
        <th style="padding: 10px; border: 1px solid #ddd;">Description</th>
    </tr>
    <tr>
        <td style="padding: 10px; border: 1px solid #ddd;">GET</td>
        <td style="padding: 10px; border: 1px solid #ddd;">api/applications/GetAllApplications</td>
        <td style="padding: 10px; border: 1px solid #ddd;">Get all applications</td>
    </tr>
    <tr>
        <td style="padding: 10px; border: 1px solid #ddd;">GET</td>
        <td style="padding: 10px; border: 1px solid #ddd;">api/applications/GetApplicationById/{id}</td>
        <td style="padding: 10px; border: 1px solid #ddd;">Get application by ID</td>
    </tr>
    <tr>
        <td style="padding: 10px; border: 1px solid #ddd;">POST</td>
        <td style="padding: 10px; border: 1px solid #ddd;">api/applications/CreateApplication</td>
        <td style="padding: 10px; border: 1px solid #ddd;">Create a new application</td>
    </tr>
    <tr>
        <td style="padding: 10px; border: 1px solid #ddd;">PUT</td>
        <td style="padding: 10px; border: 1px solid #ddd;">api/applications/UpdateApplication</td>
        <td style="padding: 10px; border: 1px solid #ddd;">Update an application</td>
    </tr>
    <tr>
        <td style="padding: 10px; border: 1px solid #ddd;">DELETE</td>
        <td style="padding: 10px; border: 1px solid #ddd;">api/applications/RemoveApplication/{id}</td>
        <td style="padding: 10px; border: 1px solid #ddd;">Delete an application</td>
    </tr>
</table>

<h2 style="color: #f39c12;">🛠 Environment Variables</h2>
<p>Create a <code>appsettings.json</code> file and configure the following:</p>
<pre style="background: #ecf0f1; padding: 10px; border-radius: 5px;">
<code>
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;"
  }
}
</code>
</pre>

<h2 style="color: #16a085;">🚀 Run Locally</h2>
<p>Run the application locally:</p>
<pre style="background: #ecf0f1; padding: 10px; border-radius: 5px;">
<code>dotnet run</code>
</pre>

<h2 style="color: #e74c3c;">📜 License</h2>
<p>MIT License</p>

<h2 style="color: #3498db;">🤝 Contribute</h2>
<p>Contributions are welcome! Fork & submit a pull request. 🚀</p>
