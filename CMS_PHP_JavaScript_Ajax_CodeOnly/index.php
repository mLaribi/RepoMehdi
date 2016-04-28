<?php
include("header.php");
?>
  <body>
	<?php
		include("includes/connexion.php");
		include("includes/menu.php");
	?>
	
    <div class="container">
        <div class="jumbotron">
		<?php
            if (isset($_GET['$id'])){
                $page = $contenu->sortirUnePage($_GET['$id']);

                echo '<h1>' . $page->getNomMenu() . '</h1>';

                echo $page->getContenu();
            }
            else
            {
                echo '<h1>Bienvenue</h1>';
            }
        ?>
            
                <!--Visionneuse-->
    <div id="carousel">
      <img id="imgAff" src="./images/Visionneuse/img1.jpg" width="600" height="400" alt="Image Surprise" title="Beaux paysage de rien"/>
      
    <!--Liste d'images chargé dynamiquement-->
        <!--Les images déependent du dossier images/visionneuse-->
      <div id="liensVignettes">
          <ul id="lstVignettes">
          <?php 
            
                $dir = "./images/Visionneuse/";
                $images = glob($dir . "*.jpg");

                for($i = 1; $i <= count($images); $i++){
                echo "<li><img id=img" . $i . " src=./images/Visionneuse/img" . $i .  ".jpg width=100 height=80 alt=img" . $i . "/></li>";
                }
             ?>
        </ul>
      
        
        </div>
        <!--Fin  Visionneuse-->
    </div>     
</div> 
      </div>    
      <!--code JavaScript du visionneuse-->
    <script type="text/javascript" src="js/visionneuse.js"></script>
       
      
<?php
  include("includes/footer.php");
?>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="js/ie10-viewport-bug-workaround.js"></script>
  </body>
</html>