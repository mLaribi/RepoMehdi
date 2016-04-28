<!DOCTYPE html>
<?php
include("header.php");
?>
  <body>
	<?php
		include("includes/connexion.php");
		include('includes/menu.php');
		require("includes/UsagerManager.php");
		$contenuUsager = new UsagerManager($bdd);
	?>

      <form methode="post" action="" id="frmRecherche">
        <input type="input" id="recherche" name="recherche" placeholder="Rechercher (login ou nom)" autocomplete="off" />
          <div id="lstUsager"></div>
        <!--<input type="submit" id="btnRecherche" type="button" value="Rechercher">-->
      </form>
  <div id="resultatClickRecherche"></div>
	<div class="panel-group" id="accordion">
	  <div class="panel panel-default">
	    <div class="panel-heading">
	      <h4 class="panel-title">
	        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
	        Ajout usager</a>
	      </h4>
	    </div>
	    <div id="collapse1" class="panel-collapse collapse in">
	      <div class="panel-body">
			<form class="form-horizontal" method="post" id="formInscription">
			<fieldset>
        <div id="msgErreur">
        </div>
			<!-- Form Name -->
			<legend>Création usager</legend>

                <div id="erreurArea">

                </div>


                <!-- Text input-->
                <div class="form-group">
                  <label class="col-md-4 control-label" for="txtPrenom">Prenom d'usager</label>
                  <div class="col-md-4">
                  <input id="txtPrenom" name="txtPrenom" type="text" placeholder="Prenom" class="form-control input-md" required="">

                  </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                  <label class="col-md-4 control-label" for="txtNom">Nom d'usager</label>
                  <div class="col-md-4">
                  <input id="txtNom" name="txtNom" type="text" placeholder="Nom" class="form-control input-md" required="">

                  </div>
                </div>
                <p id="loginExi"></p>
			<!-- Text input-->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="nomCompte">Nom du compte</label>
			  <div class="col-md-4">
			  <input id="nomCompte" name="nomCompte" type="text" placeholder="Nom d'usager" class="form-control input-md" min="3" required="">
			  </div>
			</div>

			<!-- Password input-->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="passwordAjout">Mot de passe</label>
			  <div class="col-md-4">
			    <input id="passwordAjout" name="passwordAjout" type="password" placeholder="Mot de passe" class="form-control input-md" required="">

			  </div>
			</div>

			<!-- Password input-->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="passwordAjoutConf">Confirmation mot de passe</label>
			  <div class="col-md-4">
			    <input id="passwordAjoutConf" name="passwordAjoutConf" type="password" placeholder="Confirmation mot de passe" class="form-control input-md" required="">

			  </div>
			</div>

			<!-- Select Basic -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="selectAjout">Permission</label>
			  <div class="col-md-4">
			    <select id="selectAjout" name="selectAjout" class="form-control">
			      <option value="1">Admin</option>
			      <option value="2">Membre</option>
			    </select>
			  </div>
			</div>

			<!-- Button -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="btnAjout"></label>
			  <div class="col-md-4">
			    <button id="btnAjout" name="btnAjout" class="btn btn-success" >Ajout usager</button>
			  </div>
			</div>

			</fieldset>
			</form>

			<?php
				if(isset($_POST['nomCompte']))
				{
                    $sujetAjout = new Usager(1, $_POST['nomCompte'], $_POST['passwordAjout'], $_POST['selectAjout'], $_POST['txtNom'], $_POST['txtPrenom']);

					$contenuUsager->ajouter($sujetAjout);
				}
			?>
	      </div>
	    </div>
	  </div>
	  <div class="panel panel-default">
	    <div class="panel-heading">
	      <h4 class="panel-title">
	        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
	        Modifier usager</a>
	      </h4>
	    </div>
	    <div id="collapse2" class="panel-collapse collapse">
			<form class="form-horizontal" method="post">
			<fieldset>

			<!-- Form Name -->
			<legend>Modification usager</legend>

			<!-- Select Basic -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="selectUsagerModif">Usager à modifier</label>
			  <div class="col-md-4">
			    <select id="selectUsagerModif" name="selectUsagerModif" class="form-control">
			    <?php
			    	$lstUsager = $contenuUsager->listerUsager();
			    	foreach($lstUsager as $elem)
			    	{
			    		echo '<option value="' . $elem->getId() . '">' . $elem->getLogin() .'</option>';
			    	}
			    ?>
			    </select>
			  </div>
			</div>

                <!-- Text input-->
                <div class="form-group">
                  <label class="col-md-4 control-label" for="modifPrenom">Prenom d'usager</label>
                  <div class="col-md-4">
                  <input id="modifPrenom" name="modifPrenom" type="text" placeholder="Prenom" class="form-control input-md" required="">

                  </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                  <label class="col-md-4 control-label" for="modifNom">Nom d'usager</label>
                  <div class="col-md-4">
                  <input id="modifNom" name="modifNom" type="text" placeholder="Nom" class="form-control input-md" required="">

                  </div>
                </div>

			<!-- Password input-->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="passwordAjout">Mot de passe</label>
			  <div class="col-md-4">
			    <input id="passwordModif" name="passwordModif" type="password" placeholder="Mot de passe" class="form-control input-md" required="">

			  </div>
			</div>

			<!-- Password input-->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="passwordAjoutConf">Confirmation mot de passe</label>
			  <div class="col-md-4">
			    <input id="passwordModifConf" name="passwordModifConf" type="password" placeholder="Confirmation mot de passe" class="form-control input-md" required="">

			  </div>
			</div>

			<!-- Select Basic -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="selectAjout">Permission</label>
			  <div class="col-md-4">
			    <select id="selectModif" name="selectModif" class="form-control">
			      <option value="1">Admin</option>
			      <option value="2">Membre</option>
			    </select>
			  </div>
			</div>

			<!-- Button -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="btnAjout"></label>
			  <div class="col-md-4">
			    <button id="btnModif" name="btnModif" class="btn btn-success" onclick="return confirm('Êtes-vous certain de vouloir modifier l'usager?')">Modifier usager</button>
			  </div>
			</div>

			</fieldset>
			</form>

			<?php
				if(isset($_POST['selectUsagerModif']))
				{
					$usagerModif = $contenuUsager->sortirUnUsager($_POST['selectUsagerModif']);
					$usagerApresModif = new Usager($usagerModif->getId(), $usagerModif->getLogin(), sha1($_POST['passwordModif']), $_POST['selectModif'], $_POST['modifNom'], $_POST['modifPrenom']);
					$contenuUsager->Modifier($usagerApresModif);
				}
			?>
	    </div>
	  </div>
	  <div class="panel panel-default">
	    <div class="panel-heading">
	      <h4 class="panel-title">
	        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
	        Supprimer usager</a>
	      </h4>
	    </div>
	    <div id="collapse3" class="panel-collapse collapse">
	      <div class="panel-body">
			<form class="form-horizontal" method="post">
			<fieldset>

			<!-- Form Name -->
			<legend>Supprimer usager</legend>

			<!-- Select Basic -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="selectSupp">Usager à supprimer</label>
			  <div class="col-md-4">
			    <select id="selectSupp" name="selectSupp" class="form-control">
			    <?php
			    	foreach($lstUsager as $elem)
			    	{
			    		echo '<option value="' . $elem->getId() . '">' . $elem->getLogin() .'</option>';
			    	}
			    ?>
			    </select>
			  </div>
			</div>

			<!-- Button -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="btnSupp"></label>
			  <div class="col-md-4">
			    <button id="btnSupp" name="btnSupp" class="btn btn-danger" onclick="return confirm('Êtes-vous certain de vouloir supprimer l'usager?')">Supprimer</button>
			  </div>
			</div>

			</fieldset>
			</form>

			<?php
				if(isset($_POST['selectSupp']))
				{
					$usagerSupp = $contenuUsager->sortirUnUsager($_POST['selectSupp']);
					$contenuUsager->Supprimer($usagerSupp->getId());
				}

			?>
	      </div>
	    </div>
	  </div>
	</div>
<?php
  include("includes/footer.php");
?>
      <script type="text/javascript" src="js/confirmSuppUser.js"></script>
      <script type="text/javascript" src="js/utilitaire.js"></script>
      <script type="text/javascript" src="js/valideCPUtilisateur.js"></script>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="js/ie10-viewport-bug-workaround.js"></script>
    <script src="js/recherche.js"></script>
    <script src="js/loginExistant.js"></script>
  </body>
</html>
