# ADS-FDA-Pool3
#README

Prototype Url: TBD

##Approach (158 words)

DSoft Technology uses an Agile methodology (Scrum), an iterative, incremental framework for software project development. Every two week interval is planned by the team using a tracking tool, and projects are kept on track using frequent short meetings to communicate what has been accomplished and what roadblocks are preventing progress. A Scrum Master is assigned who is responsible for removing these roadblocks and with making sure that the project stays on track.

At the beginning of the project, after writing a requirements document we add user stories and tasks to the product backlog for design, testing, and release documentation, with an estimated complexity and priority for each. Both the backlog and the requirements document are continually updated to keep up with changing requirements. Every two weeks, based on priority, we pull user stories from the product backlog and add them to the current sprint.

DSoft employs AgileSprinter™ to manage/track our Scrum process (screenshots provided under /Design/Sprint X Documents).  

##U.S. Digital Services Playbook Evidence

###a) Assigned one leader and gave that person authority and responsibility

On June 17, 2015, Kathie Reece, Category 1 Product Manager, was assigned as the team leader, responsible and accountable for the prototype delivery.

###b) Assembled a multidisciplinary and collaborative team

On June 17, 2015, M. Coon, T. Weckx, A. Brunner, M. Case, K. Lucas, D. Hollenbach, and K. Reece were assigned to team under the following categories:

| Name       | Category      |
| ---------- | ------------- |
| M. Coon    | Cat 2: Technical Architect |
| T. Weckx   | Cat 6: Frontend Web Developer      |
| A. Brunner | Cat 4: Writer/Content Designer/Content Strategist     |
| M. Case    | Cat 5: Visual Designer     |
| K. Lucas   | Cat 3: Interaction Designer/User Researcher/Usability Tester     |
| D. Hollenbach | Cat 12: Business Analyst    |
| K. Reece   | Cat 1: Product Manager     |

This was documented in /Design/Meetings/2014-06-17/MeetingNotes.md.

###c) Include people in the protype design process

See folders under /Design/Meetings. 

An initial meeting with potential users uninvolved in the design and development process was held on June 18, 2015, and was documented in /Design/Meetings/2015-06-18/MeetingNotes.md. In this meeting, users were assigned personas of a Food Researcher, Financial Analyst and a small Business Owner. An initial idea of what functionality would be useful for these personas was documented, and use cases were created.

The second paper prototype session was performed with customers on Monday, 22 June 2015, with DSoft’s Business Analyst and Visual Designer.  Customers identified changes and added requirements to the forms and resultant reports.  Changes were made to the use cases to capture changes and some requirements were deferred until the next build.

###d) Human-centered design techniques and tools

* Use Cases 
* Paper Prototyping
* Participatory Design
* Hallway Usability Testing

###e) Design Style Guide and Pattern Library

See StyleGuide.md under /Design. 

###f) Modern and open source technologies

Initial List:
* Mono (http://www.mono-project.com)
* D3.js (BSD license) (http://d3js.org)
* JSON.Net (MIT license) (http://www.newtonsoft.com/json)
* Bootstrap (MIT license) (http://getbootstrap.com)
* ASP.NET MVC5 (Apache 2.0 license) (http://www.asp.net/open-source)
* TopoJSON (https://github.com/mbostock/topojson)
* NUnit (http://www.nunit.org/)
* Postal (https://github.com/andrewdavey/postal)
* PagedList.Mvc (https://www.nuget.org/packages/PagedList.Mvc)

###g) Usability Tests

TBD

###h) Interactive Approach

See folders under /Design/Meetings. The first meeting for our iterative approach to the design was held on June 18, 2015.

Scrum meetings were held twice daily to provide status reports and roadblocks. A project status review was held on 23 June 2015 to discuss project status with the Product Manager documented in /Design/Meetings/2014-06-23/ProjectStatusReview.md

###i) Prototype

TBD

###j) Documentation

TBD

###k) Openly Licensed Technologies

Initial List:
* Mono (http://www.mono-project.com)
* D3.js (BSD license) (http://d3js.org)
* JSON.Net (MIT license) (http://www.newtonsoft.com/json)
* Bootstrap (MIT license) (http://getbootstrap.com)
* ASP.NET MVC5 (Apache 2.0 license) (http://www.asp.net/open-source)
* TopoJSON (https://github.com/mbostock/topojson)
* NUnit (http://www.nunit.org/)
* Postal (https://github.com/andrewdavey/postal)
* PagedList.Mvc (https://www.nuget.org/packages/PagedList.Mvc)

###l) Unit Tests

TBD

###m) Configuration Management

* Github (Source Control)
* TeamCity (Continuous Integration)
* Azure Web Apps (PaaS)

The deployment is fully automated using TeamCity. Commits pushed to Github trigger TeamCity build process which will pull the latest code, install / update dependencies (NuGet packages), run NUnit and code coverage. If all build steps are succesful, the build artifacts are commited to the Azure git repository which triggers an automated deployment on the Azure Staging Web App for QA / Integration tests. After success in QA, the automated deployment to Azure Production Web App is manually triggered in TeamCity.

###n) Continuous Monitoring 

Using Azure Web Apps as a PaaS comes with built-in continuous monitoring of CPU, Memory, Bandwith, HTTP errors, Response times, Page Requests. Alerts can be configured as well as automatic scaling of the underlying infrastructure based on the metrics.

###o) Deployed Software in Container

TBD
