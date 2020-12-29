<div align="center" class="row">
  <img src="https://i.imgur.com/n45IqQb.png" width="400"/>
</div>
<h3 align="center">Asclepius</h3>
<h5 align="center">A Hospial Management System</h5>
<br>

### Model Architecture-
The keras model is created by training SmallerVGGNet from scratch on around 2200 face images (~1100 for each class). Face region is cropped by applying face detection using cvlib on the images gathered from Google Images. It acheived around 96% training accuracy and ~90% validation accuracy. (20% of the dataset is used for validation)
<div align="center" class="row">
  <img src="https://i.imgur.com/8vmUpwt.jpg" width="500"/>
</div>

### Technologies used
* Tensorflow
* Keras
* Flask
* OpenCV

### Steps to run user interface
1. Run the file Gender Detection.exe

### Steps to run the application

1. `cd Gender-Paint`
   
2. `pip3 install -r requirements.txt` (only for the first time) then `python3 app.py`

3. Add or Edit the routes and functions in the file app.py



<hr>

### Authors

##### [Rabijit Singh](https://github.com/adiXcodr)
##### [Subhasish Goswami](https://github.com/subhasishgosw5)
##### [Upam Sarmah](https://github.com/upam00) 
