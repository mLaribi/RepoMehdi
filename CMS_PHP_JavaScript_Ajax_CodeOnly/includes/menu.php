<nav class="navbar navbar-default">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="index.php">C.P.A. Neufchâtel</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">

        <?php
        require("ContenuManager.php");
        try{

          $contenu = new contenuManager($bdd);
          $lstSujets = $contenu->listerSujets();
          foreach ($lstSujets as $elemSujet){
            if($elemSujet->getVisible() == 1) {
              echo '<li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">' . $elemSujet->getNomMenu() . '<span class="caret"></span></a>
              <ul class="dropdown-menu">';

                $id = $elemSujet->getId();
                $lstPages = $contenu->ListePages($id);
                foreach ($lstPages as $elemPage){
                  //afficher les pages secure et non secure
                  if(isset($_SESSION['accUsager']) == "2" || isset($_SESSION['accUsager']) == "1" ) {
                    if($elemPage->getVisible() == 1){
                      echo '<li><a href="index.php?$id='. $elemPage->getIdPage() . '">' . $elemPage->getNomMenu() . '</a></li>';
                    }

                  }
                  else {
                    if($elemPage->getSecure() == 0){
                      if($elemPage->getVisible() == 1){
                        echo '<li><a href="index.php?$id='. $elemPage->getIdPage() . '">' . $elemPage->getNomMenu() . '</a></li>';
                      }   
                    }
                  }
                }
                echo '</ul></li>';
              }
              
            }	
          }
          catch (PDOException $e){
            exit("Erreur lors de la connexion à la BD ".$e->getMessage());
          }

          ?>
        </ul>
        
        <ul class="nav navbar-nav navbar-right">
          <!-- Changer pour logout si connecter -->
          
          <?php if(isset($_SESSION['accUsager']) && $_SESSION['accUsager']== "1") : ?>
            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span class="glyphicon glyphicon-cog"></span></span> Actions sur <span class="caret"></a>
              <ul class="dropdown-menu">
                  <li><a href="controlpanelpage.php">Pages</a></li>
                  <li><a href="controlpanelsujets.php">Sujets</a></li>
                  <li><a href="controlpanelutilisateur.php">Utilisateurs</a></li>
              </ul>
            </li>

          <?php  endif; 


          if(isset($_SESSION['logUsager'])){
            echo '<li><a href="includes/logout.php"><span class="glyphicon glyphicon-log-out"></span> Se déconnecter</a></li>';
          }
          else{
            echo '<li><a href="loginform.php"><span class="glyphicon glyphicon-log-in"></span> Se connecter</a></li>';
          }
          ?>
        </ul>
      </div><!-- /.navbar-collapse -->
    </div><!-- /.container-fluid -->
  </nav>