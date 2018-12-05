## IDS6938_FinalProject-


**Write-up** of the 

### Augmented Reality project
Our goal in this project is to support some aspects of the archaeological discipline with the help of Augmented Reality. 

One of the main methods in archaeology to generate data and findings is an excavation. To ensure that the location data of a finding gathered at excavations is sufficiently accurate for scientific analysis, archaeologists usually map out a so called "dig grid" (or just "grid") onto the ground. This grid divides the excavation site into sections and supports accurate mapping of each site and finding.

Traditionally this has been done with the help of several highly specialized tools and techniques and is very precise.

With the implementation of Augmented Reality (AR) technology in conjunction with GPS devices and spatial recognition software, excavation site mapping of a grid could possibly be set-up easier and faster. Especially for time-critical exploration or limited funding operations (limited equipment, remote location), AR technology could offer an "accurate enough" approach for setting up a grid to use in an excavation.

#### Approach:

We are using a commercial smartphone and its integrated GPS and compass sensors as a baseline (being aware of the current inaccuracy injected in the GPS system) to use as the anchor/marker for the AR device. This marker, which knows its GPS coordinates and its direction/alignment (compared to true north) displays a recognizable picture/pattern on the display which the AR device (here: Microsoft HoloLens) can recognize and use to project a pattern onto the background/reality.

First step: we build an app with unity to visualize/show the coordinates of the internal GPS. The format is LAT/LON coordinates. This data is exported/sent to a server from which the HoloLens will access this data. 

Second step: build a compass app in unity which shows the alignment of the smartphone in comparison to true north. We need the alignment to later calculate the coordinates of the grid. 

![App](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/GridApp.jpg)

Third step: implement the marker functionality to be recognized into the HoloLens to use it with the smartphone. From this marker as a base, the grid will be projected.

Forth step: The grid was built in unity and attached to the marker. The grid will be projected in alignment with the marker.


#### Process:

The smartphone has to be aligned with the compass app towards true north. After the compass has stabilized, the coordinates will be sent to the server by pressing the "Send Data" button on the lower part on the screen. This transmits the LAT/LON coordinates to the server, which in turn is supposed to send it to the HoloLens. After that, push the "Turn on Marker" button to activate the marker-screen. Tab the marker projection (by finger gesture) and the grid (currently with the dimensions: 0.4976m x 0.4976m)  will appear. It will appear "on top" of the phone/marker and be on the ground plane. After activating "Enable extended tracking" (by voice command) the HoloLens can move further away from the phone/marker. 

Problems we ran into:

- The server does not communicate with the HoloLens directly, Microsoft requires certain agents to handle the communication, which was a problem that we were not able to resolve within the given time.

- We used a smaller grid than intended since the HoloLens was easily blocked out by anything larger. We assumed it will be sufficient as a proof of concept.







--------DRAFT-------

### Title

Digging in the dirt - with Virtual Reality


### Abstract

Todays archaeology is a very divers and interdisciplinary science, which uses more and more technological devices and support to be more exact, detailed and accurate. One of the main methods in archaeology to generate data and findings is the excavation. To ensure that the data gathered at excavations are standardized, comparable, and suitable for scientific analysis, there are numereous guidelines, work processes and documentation technologies, depending on the current task and location (forest, urban environment, mining underground, inside building-complexes). 
GPS devices and specialized measurement equipment (tachymeters) are now used for excavation surveying and mapping. Ideally, the measurement data can be further refined, improved or supplemented with 2D or 3D laser-scanners and other specially adapted photographic documentation measures (including aerial photography). 
With the inplementation of Augmented Reality (AR) technology in conjunction with GPS devices and spatial recognition software implemented in the VR technology, excavation site mapping could be set-up easier and faster. Especially for time-critical exploration or limited funding operations (limited equipment, remote location), AR technology could offer a well balanced and an "accurate enough" approach for setting up the required prerequisites. 


### Problem Statement

Excavation sites have to be mapped accuratly to scientically analyze the findings and to be able to reconstruct the actual outlay of the findings in a standardized fashion. Setting up a excavation site base grid, depending on task and environment, to start the excavation process is time consuming and requires highly accurate, specialized and expensive equipment. The necessary processes are time consuming and require training and expertise in the use of the specialized equipment.

![Grid](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/Grid_in_Grid.png)

Depending on the excavation site and technique selected for the task, it is not always possible to adapt the local excavation site grid to the underlying coordinates grid. Therefore, the grid has to be measured and put into reference with a standardized system so that the findings/generated data can be recorded, analyzed and reconstructed.   

Additionally, excavation sites can be local or non-conformal to a traditional grid due to location or legal constrains. Still, an accurate documentation has to be ensured. Measuring the coordinates used to be timeconsuming, as either GPS was not available yet or the necessary accuracy (within cm/less than an inch) could not be provided by (civil/available) the available GPS ccordinates. 

From a given, accurate coordinate, a grid has to be established and meaasured, usually with the help of the mentioned equipment above and with additional tools like e.g. with a especially calibrated measuring band.  


### Background

#### Tachymetre

This is how the marking of an excavation site/grid has been done (and still is) with the help of a Tachymetre.  

![Measuring step 1+2](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/measuring1.png)

In the past, correct and accurate measuring and geolocating a finding or setting up a grid to work with was a time consuming effort. Usually, the use of standardized and official measuring points/markers where the prerequisite to start from. With the use of a Tachymetre, the actual claim or excavation site was measured and marked. 


![Measuring step 3+4](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/measuring2.png)


Further points were triangulated to be used to again define the own position. There are usually at least 3 points needed to define the own position within the needed accuracy.   


![Measuring step 5](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/measuring3.png)

From the known, triangulated position, findings and special areas could be mapped and marked, exact postions generated. It is a lengthy process, which needs specialized equipment (Tachymetre) and special training to use it. While it may still be an important skill for archaeologists to be able to use and understand a Tachymetre, the use of GPS based coordinate generation is much easier and can be used in any area of the world (where the different satellite navigation systems are available).

#### Satelitte based navigation

Satellite based navigation is currently the most modern way of measuring and defining exact coordinates. In order to achive the necessary accuracy, the available GPS data has to be compared to a known, exactly measured point/coordinate and its GPS indication. Civil available satellite based navigation systems have a certain (artificially injected) inaccuracy, which can be compensated with the introduction of the second, known coordinate (e.g. survey points) and its satellite based coordinate. This process is called (pseudo-) differential GPS and can significantly improve the accuracy of any satellite based navigation system from about 15m (civil GPS accuracy, depending on the location on earth) to (ideally) up to 10 cm (4inch).   

![Grid](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/Grid2.png)

According to Müller (1998) and Gut (2013), the implemwentation of a grid (dig grid) is still the standard for developing excavation sites. The grid can be based on the existing coordinate system (aligned) or can be a local grid which must be based on accuratly defined points (survey points) or highly exact coordinates to begin with to accuratly neasure and document any findings during the excavation.  


#### Coordinate systems

Whatever the case (aligned or local grid), these grid need to be based on a coordinate system. There are several available and coordinates can be converted to the respective other systems. The two most common systems are the LAT/LON coordinate system relies on the degree, minute, and second unit of measure, which incorporates the angular system and its cumbersome units of 60. It is non-symmetrical and continually varying in both size and shape. 

![LAT/LON](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/HorizontalDatum.png)

This is due to the meridian of longitude lines—they form the left and right sides of each grid square—that curve towards each other as they depart the equator and converge at one or the other poles. While the LAT/LON coordinate system is the first choice of pilots, sailors, and others needing less-detailed, small-scale maps to navigate over great distances, other users, relying on highly-detailed, large-scale, topographic quadrangles for technical land navigation rely almost exclusively on the geospatial plane coordinate system known as the Universal Transverse Mercator (UTM) coordinate system (or Military Grid Reference System [MGRS], in the case of military).

The advantage of an UTM grid is, that all UTM coordinate grids are perfectly square and exactly the same size—1,000 meters by 1,000 meters—across the entire grid system. UTM coordinates 
+ are based on meters and the decimal system's units of ten 
+ always have the same two directional designators and never carry negative values
+ system is more accurate when using whole units only (no decimal places)
and therefore is easire to comprehend.

![UTM](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/UTMcoordinateDetail.jpg)

Due to the metric system based on 10, even lower scaling to exact coordinates within 10 cm can be described.

#### Augmented Reality

Augmented Reality can support archaeology in many forms. From blending virtual infrastructure or urbanity with the reality background to show where findings were located. As shown above, the prerequisites is to have reliable exact location data. We assume it would be a helpful application to have a grid projected (via an AR device) into the real world with coordinates and standardized length of the grid squares. So the archaeologist could use a virtual "anchor" with known position, from where a grid would be shown on the ground. This could be as a temporary grid or as an aid when other measn are not available. Depending on the interface and accuracy, it could also become a new means of setting the dig grid onto the excavation site. 

![ARGrid](https://github.com/valdeezzee/IDS6938_FinalProject-/blob/master/Ausgrabung/ARGrid2.jpg)

In our project, our goal is to investigate several areas:
+ can we blend an exactly measured grid (e.g. 3x5 m) onto reality
+ can we use the AR device to extract coordinates of each point on the grid
+ can we use the AR device to extract coordinates of any given point in the field of view (FoV), within a certain range
+ what is neccessary to use as an "anchor" for the device to receive and translate the position/location
+ how accurate is the grid/AR device in the grid representation

(This section provides the background information required for the audience to grasp the problem and, ultimately, the solution. The content may detailed and technical or broad and high-level. The content depends on the reader and the problem.
If original research is completed for the white paper, the methods should be communicated.)

### Solution

(The ‘ta-da’ moment of the white paper.
Based on the preceding information, the solution is now presented. It is developed and argued for using the gathered evidence and the expertise of the author and their company.)

### Conclusion

(This section summarizes the white paper’s major findings. Recommendations based on the solution are provided.)

### References

Wikipedia (2018), Differentila GPS, Retrieved November 20, 2018, from: https://en.wikipedia.org/wiki/Differential_GPS

Müller, D. (1998), Methoden der Grabungsvermessung, in: Biel, J., Klonk, D., Handbuch der Grabungstechnik, Stuttgart 1998, Retrieved November 21, 2018, from: http://www.landesarchaeologen.de/fileadmin/Dokumente/Dokumente_Kommissionen/Dokumente_Grabungstechniker/Grabungstechnikerhandbuch/14.1_Absteckung_und_Abmarkung.pdf

Suhrbier, S. (2011), Anleitung zur digitalen Vermessung auf Archäologischen Ausgrabungen, Academia.eu, Retrieved November 15, 2018, from:  https://www.academia.edu/11900739/Anleitung_zur_digitalen_Vermessung_auf_Archäologischen_Ausgrabungen

Gut, M. (2013), Dokumentation und Datenerfassung auf Ausgrabungen - Magisterarbeit, Retrieved November 22, 2018, from: https://archiv.ub.uni-heidelberg.de/volltextserver/17847/1/magisterarbeit.pdf

GISGeography.com (2018), Latitude, Longitude and Coordinate System Grids, Retrieved November 26, 2018, from: https://gisgeography.com/latitude-longitude-coordinates/

Neiger, M. A. (2010), The Universal Transverse Mercator (UTM) coordinate system, in: Michigan Backcountry Search and Rescue (MiBSAR), Retrieved November 26, 2018, from: http://www.mibsar.com/LandNav/UTM/UTM.htm

Scott, R. (2017), Morpholio's New AR Feature Makes Perspective Sketching Easier—And More Accurate—Than Ever Before, in: Arch Daily, Retrieved November 27, 2018, from: https://www.archdaily.com/879952/morpholios-new-ar-feature-makes-perspective-sketching-easier-and-more-accurate-than-ever-before

------------------------------------------------------------------

Unity version: 2017.4.1f1

## Helpful Link

Setting up environment for Hololens development:
[**Install the tools**](https://docs.microsoft.com/en-us/windows/mixed-reality/install-the-tools)

Tutorials:
[**Mixed Reality Academy**](https://docs.microsoft.com/en-us/windows/mixed-reality/academy)
 
[**MR Basics 101**](https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101)


