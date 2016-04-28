<?php
include("header.php");
?>
<body>
    <?php
    include("includes/connexion.php");
    include("includes/menu.php");
    ?>

<div class="container">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <h1 class="text-center login-title">Connexion d'usager</h1>
            <?php
      				if(isset($_GET['code']))
      				{
      					echo '<p>Mauvais identifiants</p>';
      				}
      			?>
            <div class="account-wall">
                <form class="form-signin" action="includes/UsagerConnect.php" method="post">
                <input name="nomUsager" type="text" class="form-control" placeholder="Nom d'usager" maxlength="50"
						size="40" required autofocus
                       <?php
						if (isset ( $_COOKIE ['sessionAuto'] ))
						{
							echo "value=" . $_COOKIE ['sessionAuto'];
						}
						?>
                       />
                <input name="motPasse" type="password" class="form-control" placeholder="Mot de passe" maxlength="50"
						size="40" required />
                <input class="btn btn-lg btn-primary btn-block" type="submit" value="Connexion" name="Connexion" />

                <label class="checkbox pull-left">
                    <input name="seSouvenir" type="checkbox" value="true" checked />
                    Se souvenir
                </label>
                </form>
            </div>
        </div>
    </div>
</div>

<?php
  include("includes/footer.php");
?>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <!-- <script src="js/ie10-viewport-bug-workaround.js"></script>-->
  </body>
</html>
