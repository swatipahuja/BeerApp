Description:
BeerFinder fetches the details related to a beer that we type in search bar. The user can filter based on Category and Glassware. Also sorting can be done based on Name, IBV and IBU.

Deployment:
1. Pull Publish folder from location: https://github.com/swatipahuja/BeerApp/tree/master/BeerFinder
2. Deploy BeerFinderService in IIS. 

Pre-requisites:
a. .Net fremework 4.5 should be installed.
b. WCF HTTP Activation windows feature should be enabled.

Steps for deployment of service:
a. Click on start and type inetmgr
b. Open IIS. In left panel you will see Connections. Expand server name and then expand Sites.
c. Right click on sites and select 'Add Website' option.
d. Write the site name as 'BeerFinderService'
e. Point 'Content Directory' to BeerFinderService folder.
f. In port enter 49164.
g. Click on OK.
h. Browse http://localhost:49165/ and see that it is listing the BeerFinder Service.

3. Deploy BeerFinderWebPortal in IIS.

Steps for deployment of Web App:
a. Click on start and type inetmgr
b. Open IIS. In left panel, you will see Connections. Expand server name and then expand Sites.
c. Right click on sites and select 'Add Website' option.
d. Write the site name as 'BeerFinderWebApp'
e. Point 'Content Directory' to BeerFinderWebApp folder.
f. In port enter any available port.
g. Click on OK.
h. Browse http://localhost:<PORT_NUMBER>/ and you will be able to see the website.
i. Whichever port number you enter, that should be updated in service web.config file for property 'Access-Control-Allow-Origin'

Technologies:
- [AngularJS 1.3](https://angularjs.org/) (Framework)
- [NodeJS](http://nodejs.org/)  (Build)
- [GulpJS](http://gulpjs.com/)  (Build Processes)
- [WCF] (REST Service)
- [NUnit] (Testing)
- [Nsubstitute] (Mocking) 
- [.Net 4.5] (Framework) 


