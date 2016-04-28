<?php
include("header.php");
?>
<script type="text/javascript" src="ckeditor/ckeditor.js"></script>
  <body>
	<?php
		include("includes/connexion.php");
		include('includes/menu.php');
        $maxPos = 0;
        foreach($lstSujets as $elemSujet){
        $lstPageParSujet = $contenu->ListePages($elemSujet->getId());
            if($maxPos < (count($lstPageParSujet) + 1)){
            $maxPos = (count($lstPageParSujet) + 1);
            }
         }
	?>

	<div class="panel-group" id="accordion">
	  <div class="panel panel-default">
	    <div class="panel-heading">
	      <h4 class="panel-title">
	        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
	        Ajout page</a>
	      </h4>
	    </div>
	    <div id="collapse1" class="panel-collapse collapse in">
	      <div class="panel-body">


			              <form class="form-horizontal" method="post">
			<fieldset>

			<!-- Form Name -->
			<legend>Ajout d'une page</legend>

			<!-- Text input-->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="nomPage">Nom de la page</label>
			  <div class="col-md-4">
			  <input id="nomPage" name="nomPage" type="text" placeholder="" class="form-control input-md" required="">

			  </div>
			</div>

			<div class="form-group">
			  <label class="col-md-4 control-label" for="contenu">Contenu de la page</label>
			  <div class="col-md-4">
			        <textarea class="ckeditor" name="editor"></textarea>
			  </div>
			</div>

			    <!-- Select Basic -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="sujet">Sujet relié</label>
			  <div class="col-md-4">
			    <select id="sujet" name="sujet" class="form-control" required="">
			        <?php
			            foreach($lstSujets as $elem){
			            echo '<option value="' . $elem->getId() .'">' . $elem->getNomMenu() . '</option>';
			            }
			        ?>
			    </select>
			  </div>
			</div>

			<!-- Select Basic -->
			<div class="form-group">
			<label class="col-md-4 control-label" for="position">Position</label>
			    <div class="col-md-1">
			            <input type ="number" id="position" name="positionAjout" class="form-control" min="1" <?php echo 'max="'. $maxPos . '"';?>>

			        </input>

			    </div>
			</div>

			<!-- Multiple Radios -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="visible">Visibilité</label>
			  <div class="col-md-4">
			  <div class="radio">
			    <label for="visible-0">
			      <input type="radio" name="visible" id="visible-0" value="1" checked="checked">
			      Visible
			    </label>
				</div>

			  <div class="radio">
			    <label for="visible-1">
			      <input type="radio" name="visible" id="visible-1" value="0">
			      Invisible
			    </label>
				</div>
			  </div>
			</div>

			<!-- Multiple Radios -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="accessiblité">Accessibilité</label>
			  <div class="col-md-4">
			  <div class="radio">
			    <label for="accessiblité-0">
			      <input type="radio" name="accessiblité" id="accessiblité-0" value="1" checked="checked">
			      Administrateur seulement
			    </label>
				</div>
			  <div class="radio">
			    <label for="accessiblité-1">
			      <input type="radio" name="accessiblité" id="accessiblité-1" value="0">
			      Tout le monde
			    </label>
				</div>
			  </div>
			</div>

			<!-- Button -->
			<div class="form-group">
			  <label class="col-md-4 control-label" for="ajouterPage"></label>
			  <div class="col-md-4">
			    <button id="ajouterPage" name="ajouterPage" class="btn btn-primary">Ajouter page</button>
			  </div>
			</div>



			</fieldset>
			</form>

			            <?php
			                 if(isset($_POST['nomPage'])){


			                   $lstPageSujetSelect = $contenu->ListePages($_POST['sujet']);

			                   //décalage
			                   foreach($lstPageSujetSelect as $elem)
			                   {
			                     if($elem->getPosition() >= $_POST['positionAjout'])
			                     {
			                     	$elem->setPosition($elem->getPosition() + 1);
			                     	$contenu->ModifierPageBD($elem);
			                     }
			                   }

			                   if($_POST['positionAjout'] > count($lstPageSujetSelect))
			                   {
			                   		$posAjout = count($lstPageSujetSelect) + 1;
			                   }
			                   else
			                   {
			                   		$posAjout = $_POST['positionAjout'];
			                   }

			                   $page = new Page($maxPos, $_POST['sujet'], $_POST['nomPage'], $posAjout, $_POST['visible'], $_POST['editor'], $_POST['accessiblité']);
			                   $contenu->AjoutPage($page);
			                }
			            ?>
					</div>
			    </div>
			  </div>
				<div class="panel panel-default">
				     <div class="panel-heading">
				       <h4 class="panel-title">
				         <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
				         Modifier page</a>
				       </h4>
				     </div>
				     <div id="collapse2" class="panel-collapse collapse">
				       <div class="panel-body">
				                   <form class="form-horizontal" method="post">
				<fieldset>

				<!-- Form Name -->
				<legend>Modification d'une page</legend>

				<!-- Text input-->
				<div class="form-group">
				  <label class="col-md-4 control-label" for="sujetModif">Nom de la page</label>
				  <div class="col-md-4">
				   <select id="sujet" name="sujetModif" class="form-control" required="" >
				     <?php
				            $ttePages = $contenu->ListerToutesLesPages();
				            foreach($ttePages as $elem){
				            echo '<option value="' . $elem->getIdPage() .'">' . $elem->getNomMenu() . '</option>';
				            }
				        ?>
				      </select>
				  </div>
				</div>

				<div class="form-group">
				              <label class="col-md-4 control-label" for="nomModif">Nouveau nom</label>
				              <div class="col-md-5">
				                <input id="nomModif" name="nomModif" type="text" placeholder="Nom du sujet" class="form-control input-md" required="">
				              </div>
				            </div>

				<div class="form-group">
				  <label class="col-md-4 control-label" for="editorModif">Contenu de la page</label>
				  <div class="col-md-4">
				        <textarea class="ckeditor" name="editorModif"></textarea>
				  </div>
				</div>

				    <!-- Select Basic -->
				<div class="form-group">
				  <label class="col-md-4 control-label" for="sujetModif">Sujet relié</label>
				  <div class="col-md-4">
				    <select id="sujet" name="sujetModif" class="form-control" required="">
				     <?php
				            foreach($lstSujets as $elem){
				            echo '<option value="' . $elem->getId() .'">' . $elem->getNomMenu() . '</option>';
				            }
				        ?>
				    </select>
				  </div>
				</div>

				<!-- Select Basic -->
				<div class="form-group">
				<label class="col-md-4 control-label" for="positionModif">Position</label>
				    <div class="col-md-1">
				            <input type ="number" id="positionModif" name="positionModif" class="form-control" min="1" <?php echo 'max="'. $maxPos . '"';?>>

				        </input>

				    </div>
				</div>

				<!-- Multiple Radios -->
				<div class="form-group">
				  <label class="col-md-4 control-label" for="visibleModif">Visibilité</label>
				  <div class="col-md-4">
				  <div class="radio">
				    <label for="visible-0">
				      <input type="radio" name="visibleModif" id="visible-0" value="1" checked="checked">
				      Visible
				    </label>
				 </div>

				  <div class="radio">
				    <label for="visible-1">
				      <input type="radio" name="visibleModif" id="visible-1" value="0">
				      Invisible
				    </label>
				 </div>
				  </div>
				</div>

				<!-- Multiple Radios -->
				<div class="form-group">
				  <label class="col-md-4 control-label" for="accessiblitéModif">Accessibilité</label>
				  <div class="col-md-4">
				  <div class="radio">
				    <label for="accessiblité-0">
				      <input type="radio" name="accessiblitéModif" id="accessiblité-0" value="1" checked="checked">
				      Administrateur seulement
				    </label>
				 </div>
				  <div class="radio">
				    <label for="accessiblité-1">
				      <input type="radio" name="accessiblitéModif" id="accessiblité-1" value="0">
				      Tout le monde
				    </label>
				 </div>
				  </div>
				</div>

				<!-- Button -->
				<div class="form-group">
				  <label class="col-md-4 control-label" for="modifPage"></label>
				  <div class="col-md-4">
				    <button id="ajouterPage" name="modifPage" class="btn btn-primary">Modifier page</button>
				  </div>
				</div>



				</fieldset>
				</form>

				            <?php
				                if(isset($_POST['nomModif'])){
				                $pageModif = $contenu->sortirUnePage($_POST['sujetModif']);
				                $lstPageDuSujet = $contenu->ListePages($pageModif->getSujet());
				                //décalage si page apres
				                	if($_POST['positionModif'] > $pageModif->getPosition())
				                	{
				                		foreach($lstPageDuSujet as $elem)
				                		{
					                		if($elem->getPosition() > $pageModif->getPosition() && $elem->getPosition() <= $_POST['positionModif'])
					                		{
					                			$elem->setPosition($elem->getPosition() - 1);
					                			$contenu->ModifierPageBD($elem);
					                		}
				                		}
				                	}

				                //décalage si page avant
				                	if($_POST['positionModif'] < $pageModif->getPosition())
				                	{
				                		foreach($lstPageDuSujet as $elem)
				                		{
					                		if($elem->getPosition() < $pageModif->getPosition() && $elem->getPosition() >= $_POST['positionModif'])
					                		{
					                			$elem->setPosition($elem->getPosition() + 1);
					                			$contenu->ModifierPageBD($elem);
					                		}
				                		}
				                	}

				                $page = new Page($pageModif->getIdPage(), $_POST['sujetModif'], $_POST['nomModif'], $_POST['positionModif'], $_POST['visibleModif'], $_POST['editorModif'], $_POST['accessibliteModif']);
				                    $contenu->ModifierPageBD($page);
				                     echo '<p>Les modifications seront visible au changement de page.</p>';
				                }
				            ?>
				            </div>
				     </div>
				   </div>
	  <div class="panel panel-default">
	    <div class="panel-heading">
	      <h4 class="panel-title">
	        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
	        Supprimer page</a>
	      </h4>
	    </div>
	    <div id="collapse3" class="panel-collapse collapse">
	      <div class="panel-body">
            <form class="form-horizontal" method="post">
<fieldset>

<!-- Form Name -->
<legend>Supprimer page</legend>

<!-- Select Basic -->
<div class="form-group">
  <label class="col-md-4 control-label" for="page">Page :</label>
  <div class="col-md-4">
    <select id="pageSupp" name="pageSupp" class="form-control">
    <?php
    	$toutLesPage = $contenu->ListerToutesLesPages();

    	foreach($toutLesPage as $elem)
    	{
    		echo '<option value="' . $elem->getIdPage() . '">' . $elem->getNomMenu() . '</option>';
    	}
    ?>
    </select>
  </div>
</div>

<!-- Button -->
<div class="form-group">
  <label class="col-md-4 control-label" for="supprimer"></label>
  <div class="col-md-4">
    <button id="supprimer" name="supprimer" class="btn btn-danger">Supprimer</button>
  </div>
</div>

</fieldset>
</form>

                    <?php
              		if(isset($_POST['pageSupp']))
              		{

              			$pageSupprimer = $contenu->sortirUnePage($_POST['pageSupp']);

              			$contenu->SupprimerPageBD($_POST['pageSupp']);

              			//décalage
              			$lstPage = $contenu->ListePages($pageSupprimer->getSujet());
              			foreach($lstPage as $elem)
              			{
              				if($elem->getPosition() > $pageSupprimer->getPosition())
              				{
              					$elem->setPosition($elem->getPosition() - 1);
              					$contenu->ModifierPageBD($elem);
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
    <script type="text/javascript" src="js/confirmSuppPage.js"></script>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="js/ie10-viewport-bug-workaround.js"></script>
  </body>
</html>
