# ADS-FDA-Pool3
#README

* Prototype URL: http://dsoft-ads.azurewebsites.net
* GitHub URL: https://github.com/DSoftTechnology/ADS-FDA-Pool3

The DSoft Technology ADS Pool 3 prototype and submission meets all the evidence criteria listed in the Design Pool 3 and exercises/uses 7 (of 13) labor categories from the Full Stack Pool 3 categories.

##Full Stack Approach

DSoft Technology uses an Agile methodology (Scrum), an iterative, incremental framework for software project development. Every two week interval is planned by the team using a tracking tool, and projects are kept on track using frequent short meetings to communicate what has been accomplished and what roadblocks are preventing progress. A Scrum Master is assigned who is responsible for working with project managers to remove these roadblocks and to make sure that the project stays on track.  At the beginning of the project, after writing a brief requirements document we add use cases and user stories and tasks to the product backlog for design, testing, and release documentation, with an estimated complexity and priority for each. Both the backlog and the requirements document are continually updated to keep up with changing user requirements. Every two weeks, based on priority, we pull user stories from the product backlog and add them to the current sprint. DSoft employs our internally-developed AgileSprinter™ tool to manage/track our Scrum process (screenshots provided under /Design/Sprint 1 Documents).  

##U.S. Digital Services Playbook Evidence

###a) Assigned one leader and gave that person authority and responsibility

On June 17, 2015, K. Reece, Category 1 Product Manager, was assigned as the team leader, responsible and accountable for the prototype delivery.  Ms. Reece has the skillset (long time IT project manager and certified Scrum Master) to perform this role.  Her bio is located in ...ADS-FDA-Pool3 / Design / Meetings / 2015-06-17 / ProductManagerAppointment.md

###b) Assembled a multidisciplinary and collaborative team

On June 17, 2015, team members were assigned to team under the following ADS labor categories:

| Name       | Category      |
| ---------- | ------------- |
| M. Coon    | Cat 2: Technical Architect |
| T. Weckx   | Cat 6: Frontend Web Developer      |
| A. Brunner | Cat 4: Writer/Content Designer/Content Strategist     |
| M. Case    | Cat 5: Visual Designer     |
| K. Lucas   | Cat 3: Interaction Designer/User Researcher/Usability Tester     |
| D. Hollenbach | Cat 12: Business Analyst    |
| K. Reece   | Cat 1: Product Manager     |

This assignment was documented in ......ADS-FDA-Pool3/Design/Meetings/2014-06-17/MeetingNotes.md

###c) Understand what people need

The entire project was conducted with human-centered design and tools.  Changes were continuously integrated, deployed on a staging system and tested, and then provided back to users for their reactions and additional inputs.

See ...ADS-FDA-Pool3/Design/

###d) Used at least 3 human-centered design techniques

The entire project was conducted with human-centered design and tools.  Changes were continuously integrated, deployed on a staging system and tested, and then provided back to users for their reactions and additional inputs.

* 1) Brainstorming sessions - worked within the project team to brainstorm concepts and wireframes for development to meet user needs; developed a user navigation map
* 2) Use Cases - 3 iterations centered on the identified 3 primary personas (not potential FDA data maintainer personas)
* 3) Paper Prototyping - 3 iterations with 3 primary personas and using comments to affect design
* 4) Participatory Design - multiple live demonstrations (using both test data for quick reviews and FDA data once that capability was integrated) showing prototypes to various users and incorporating their comments to inform/affect design
* 5) Usability Testing - Performed 1 iteration with uninvolved, non-IT users; invited non-IT users to use the website and provide feedback

###k) Documentation to install and run prototype on different machine

TBD - Provided instructions for Windows and Linux.

###l) Continuous integration

###e) Created or used a design style guide

See StyleGuide.md under ...ADS-FDA-Pool3/Design. 

###f) Performed usability tests with people

* To put the "needs of users first", we provided usability testing
* Performed usability tests with non-IT volunteers
* See Usability Test Plan under ...ADS-FDA-Pool3./Design

###g) Used an iterative approach

Personas were involved in every iteration through general discussions, paper prototyping, demonstrations and testing.  See folders under ...ADS-FDA-Pool3/Design/Meetings. 

An initial meeting with potential users uninvolved in the design and development process was held on June 18, 2015, and was documented in /Design/Meetings/2015-06-18/MeetingNotes.md. In this meeting, users were assigned personas of a Food Researcher, Financial Analyst and a small Business Owner. An initial idea of what functionality would be useful for these personas was documented, and use cases were created.

The second paper prototype session was performed with customers on Monday, 22 June 2015, with DSoft’s Business Analyst and Visual Designer.  Customers/Personas identified changes and added requirements to the web forms and resultant reports (generated from open.FDA.gov).  Changes were made to the use cases to capture changes, separate variants of the use case. Some requirements were deferred until the next build.

A 3rd paper prototyping session was held with the Financial Analyst becuase we determined the dataset was limited and may not be able to provide the exact report she requested.

Live demonstrations of the prototypes were provided to users whose comments were reflected back into the design when possible.

###h) Created a prototype that works with multiple devices

###i) Used at least 5 modern and open source technologies

The following were used in the design and development of the ADS prototype:
* Mono (http://www.mono-project.com)
* D3.js (BSD license) (http://d3js.org)
* JSON.Net (MIT license) (http://www.newtonsoft.com/json)
* Bootstrap (MIT license) (http://getbootstrap.com)
* ASP.NET MVC5 (Apache 2.0 license) (http://www.asp.net/open-source)
* TopoJSON (https://github.com/mbostock/topojson)
* NUnit (http://www.nunit.org/)
* Postal (https://github.com/andrewdavey/postal)
* PagedList.Mvc (https://www.nuget.org/packages/PagedList.Mvc)

###j) Deployed prototype on an IaaS or PaaS provider

Deployed on ADS protype on Microsoft Azure Web Services, a PaaS provider.  Azure supports aselection of operating systems, programming languages, frameworks, tools, databases and devices: runs apps with JavaScript, Python, .NET, PHP, Java, Node.js; provides build backends for iOS, Android, and Windows devices.

###k) Wrote unit tests for code

* Created automated tests to verify all user-facing functionality
* Test Plan finalized on 25 June 2015
* Testing team session planned for Friday, 26 June 2015 using multiple mobile devices and various operating systems with users unfamiliar with system and development
* All web forms were tested for browser compatibility on major browsers

Tests documented in ...ADS-FDA-Pool3/tree/master/Test

###l) Continuous Integration System

The ADS protype deployment is fully automated using TeamCity. Commits pushed to Github trigger a TeamCity build process which will pull the latest code, install / update dependencies (NuGet packages), run NUnit and code coverage. If all build steps are succesful, the build artifacts are commited to the Azure git repository which triggers an automated deployment on the Azure Staging Web App for QA / Integration tests. After success in QA, the automated deployment to Azure Production Web App is manually triggered in TeamCity.

###m) Configuration Management

Configuration management tools used include:
* Github (Source Control)
* TeamCity (Continuous Integration)
* Azure Web Apps (PaaS)

###n) Continuous Monitoring

Using Azure Web Apps as a Platform as a Service (PaaS) comes with built-in continuous monitoring of CPU, Memory, Bandwith, HTTP errors, Response times, Page Requests. Alerts can be configured as well as automatic scaling of the underlying infrastructure based on the metrics.  Reference Web Apps Dashboard here: https://azure.microsoft.com/en-us/documentation/articles/web-sites-monitor/

###o) Deploy software in a container

TBD


###p) Install and run prototype on another machine

###q) Prototype and underlying platforms used to create and run prototype are openly licensed and free of charge

The following were used to create and run the ADS prototype:
* Mono (http://www.mono-project.com)
* D3.js (BSD license) (http://d3js.org)
* JSON.Net (MIT license) (http://www.newtonsoft.com/json)
* Bootstrap (MIT license) (http://getbootstrap.com)
* ASP.NET MVC5 (Apache 2.0 license) (http://www.asp.net/open-source)
* TopoJSON (https://github.com/mbostock/topojson)
* NUnit (http://www.nunit.org/)
* Postal (https://github.com/andrewdavey/postal)
* PagedList.Mvc (https://www.nuget.org/packages/PagedList.Mvc)

DSoft Technology hosted our prototype website on Azure web services, a PaaS.  The prototype was developed in Mono v1.0.5, an open source development platform based on the .Net framework that allows developers to build Linux and cross-platform applications. Websites built with Mono can be run on Apache using the mod_mono module. Mono, Apache and the mod_mono module are open source and free of charge.  
