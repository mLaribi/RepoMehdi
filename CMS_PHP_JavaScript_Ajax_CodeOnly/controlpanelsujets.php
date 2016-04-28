<!DOCTYPE html>
    <?php
    include("header.php");
    ?>

  <body>
	<?php
		include("includes/connexion.php");
		include('includes/menu.php');
        $maxPos = count($lstSujets) + 1;
        $maxPosModif = count($lstSujets);
	?>

    <div class="panel-group" id="accordion">
      <div class="panel panel-default">
        <div class="panel-heading">
          <h4 class="panel-title">
            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
            Ajouter Sujet</a>
          </h4>
        </div>
        <div id="collapse1" class="panel-collapse collapse in">
          <div class="panel-body">
            <form class="form-horizontal" method="post">
            <fieldset>
            <!-- Form Name -->
            <legend>Ajout d'un sujet</legend>

            <!-- Text input-->
            <div class="form-group">
              <label class="col-md-4 control-label" for="nomSujet">Nom</label>
              <div class="col-md-5">
                <input id="nomSujet" name="nomAjoutSujet" type="text" placeholder="Nom du sujet" class="form-control input-md" required="">
              </div>
            </div>

            <!-- Select Basic -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="position">Position</label>
              <div class="col-md-1">
                <input type ="number" id="position" name="positionAjout" class="form-control" min="1" <?php echo 'max="'. $maxPos . '"'; ?>>
                </input>
              </div>
            </div>

            <!-- Multiple Checkboxes -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="checkboxes">Visibilité</label>
              <div class="col-md-4">
              <div class="checkbox">
                <label for="checkboxes-0">
                  <input type="checkbox" name="checkboxesAjout" id="checkboxes-0" value="true">
                  Oui
                </label>
                </div>
              </div>
            </div>

            <!-- Button -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="btnAjouter"></label>
              <div class="col-md-4">
                <button id="btnAjouter" name="btnAjouter" class="btn btn-success" type="submit" onclick="return confirm('Êtes-vous certain de vouloir ajouter le sujet?')">Ajouter Page</button>
              </div>
            </div>

            </fieldset>
            </form>

            <?php
                 if(isset($_POST['nomAjoutSujet'])){
                    if ($_POST['checkboxesAjout'] == 'true') {
                        $visible = 1;
                    }
                    else{
                        $visible = 0;
                    }

                    //décalage
                    foreach($lstSujets as $elem){
                     if($elem->getPosition() >= $_POST['positionAjout']){
                        $elem->setPosition($elem->getPosition() + 1);
                        $contenu->ModifierSujet($elem);
                     }
                    }

                    $sujet = new Sujet($visible, $_POST['nomAjoutSujet'], $_POST['positionAjout'], $visible);
                    $contenu->AjoutSujet($sujet);
                 }
            ?>
          </div>
      </div>
          </div>
        </div>
      </div>
      <div class="panel panel-default">
        <div class="panel-heading">
          <h4 class="panel-title">
            <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
            Modifier Sujet</a>
          </h4>
        </div>

        <div id="collapse2" class="panel-collapse collapse">
          <div class="panel-body">
            <form class="form-horizontal" method="post">
            <fieldset>
            <!-- Form Name -->
            <legend>Modifier d'un sujet</legend>

            <!-- Select Basic -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="position">Sujet à modifier</label>
              <div class="col-md-1">
                <select id="idModif" name="idModif" class="form-control">
                <?php
                    foreach($lstSujets as $elem)
                    {
                        echo '<option value="' . $elem->getId() .'">' . $elem->getNomMenu() . '</option>';
                    }
                ?>
                </select>
              </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
              <label class="col-md-4 control-label" for="nomSujet">Nom</label>
              <div class="col-md-5">
                <input id="nomSujetModif" name="nomSujetModif" type="text" placeholder="Nom du sujet" class="form-control input-md" required="">
              </div>
            </div>

            <!-- Select Basic -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="position">Position</label>
              <div class="col-md-1">
                <input type ="number" id="position" name="positionModif" class="form-control" min="1" <?php echo 'max="'. $maxPosModif . '"'; ?>>
                </input>
              </div>
            </div>

            <!-- Multiple Checkboxes -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="checkboxes">Visibilité</label>
              <div class="col-md-4">
              <div class="checkbox">
                <label for="checkboxes-0">
                  <input type="checkbox" name="checkboxesModif" id="checkboxes-0" value="true">
                  Oui
                </label>
                </div>
              </div>
            </div>

            <!-- Button -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="btnAjouter"></label>
              <div class="col-md-4">
                <button id="btnModif" name="btnModif" class="btn btn-success" type="submit" onclick="return confirm('Êtes-vous certain de vouloir modifier le sujet?')">Modifier Page</button>
              </div>
            </div>

            </fieldset>
            </form>
            <?php
                if (isset($_POST['nomSujetModif'])){
                    $sujetModif = $contenu->sortirUnSujet($_POST['idModif']);
                    if ($_POST['checkboxesModif'] == 'true')
                        $visible = 1;
                    else
                        $visible = 0;

                    //décalage si sujet monte
                    if($_POST['positionModif'] > $sujetModif->getPosition()) {
                        foreach($lstSujets as $elem)
                        {
                            if($elem->getPosition() > $sujetModif->getPosition() && $elem->getPosition() <= $_POST['positionModif'])
                            {
                                $elem->setPosition($elem->getPosition() - 1);
                                $contenu->ModifierSujet($elem);
                            }
                        }
                    }

                    //décalage si descend
                    if($_POST['positionModif'] < $sujetModif->getPosition()) {
                        foreach($lstSujets as $elem)
                        {
                            if($elem->getPosition() < $sujetModif->getPosition() && $elem->getPosition() >= $_POST['positionModif'])
                            {
                                $elem->setPosition($elem->getPosition() + 1);
                                $contenu->ModifierSujet($elem);
                            }
                        }
                    }

                     $sujet = new Sujet($_POST['idModif'], $_POST['nomSujetModif'], $_POST['positionModif'], $visible);
                     $contenu->ModifierSujet($sujet);
                     header("location: index.php");
                     exit;
                     echo '<p>Les modifications seront visible au changement de page.</p>';
                }
            ?>

          </div>
      </div>
          </div>
        </div>
      </div>
      <div class="panel panel-default">
        <div class="panel-heading">
          <h4 class="panel-title">
            <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
            Supprimer Sujet</a>
          </h4>
        </div>
        <div id="collapse3" class="panel-collapse collapse">
          <div class="panel-body">
            <form class="form-horizontal" method="post">
            <fieldset>

            <!-- Form Name -->
            <legend>Supprimer d'un sujet</legend>

            <!-- Select Basic -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="selectSujet">Sujet à supprimer</label>
              <div class="col-md-4">
                <select id="selectSujetSupp" name="selectSujetSupp" class="form-control">
                <?php
                    foreach($lstSujets as $elem)
                    {
                        echo '<option value="' . $elem->getId() .'">' . $elem->getNomMenu() . '</option>';
                    }
                ?>
                </select>
              </div>
            </div>

            <!-- Button -->
            <div class="form-group">
              <label class="col-md-4 control-label" for="btnSupprimer"></label>
              <div class="col-md-4">
                <button id="btnSupprimer" name="btnSupprimer" class="btn btn-danger" type="submit" >Supprimer sujet</button>
              </div>
            </div>

            </fieldset>
            </form>

            <?php
                if(isset($_POST['selectSujetSupp']))
                {
                    $sujetSupp = $contenu->sortirUnSujet($_POST['selectSujetSupp']);
                    $contenu->SupprimerSujet($_POST['selectSujetSupp']);

                    $lstPageParSujet = $contenu->ListePages($sujetSupp->getSujet());

                    //décalage
                    foreach($lstSujets as $elem)
                    {
                        if($elem->getPosition() > $sujetSupp->getPosition())
                        {
                            $elem->setPosition($elem->getPosition() - 1);
                            $contenu->ModifierSujet($elem);
                        }
                    }
                }
            ?>
          </div>
        </div>
      </div>
    </div>
<?php
  include("includes/footer.php");
?>

<script type="text/javascript" src="js/confirmSuppSujet.js"></script>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="js/ie10-viewport-bug-workaround.js"></script>
  </body>
</html>
