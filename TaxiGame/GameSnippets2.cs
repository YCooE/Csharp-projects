Using System;


/// <summary >
/// Saves the game to a file .
/// </ summary >
public void SaveGame ( string fileNumber )
{
    _gameState = new GameState ( _parser._levelNumber, Player.
    Shape.X , Player.Shape.Y ) ;
    var path = AppDomain.CurrentDomain.BaseDirectory + "
    SaveFiles " + Path.DirectorySeparatorChar + " DataFile " +
    fileNumber + ".dat";
    FileStream fs = new FileStream ( path, FileMode.Create ) ;

    BinaryFormatter formatter = new BinaryFormatter () ;

    try
        {
            formatter.Serialize ( fs, _gameState ) ;
        }
    catch ( SerializationException e )
        {
            Console.WriteLine ( e.Message ) ;
        throw ;
        }
    finally
        {
            fs.Close() ;
        }
}


/// <summary >
/// Loads the game from a file .
/// </ summary >
/// <remarks >
/// This deviates from the given assignment by not taking aparameter gameState
/// </ remarks >
public void LoadGame ( string fileNumber )
{
    var path = AppDomain . CurrentDomain . BaseDirectory + "
    SaveFiles " + Path . DirectorySeparatorChar + " DataFile "
    + fileNumber + ".dat";
    if ( File . Exists ( path ) )
        {
        Deserialize ( fileNumber ) ;
        _entities . Clear () ;
        _parser . _levelNumber = _gameState . _levelNumber ;
        _parser . ParseFile () ;
        LoadLevel ( false ) ;
        InitializePlayer ( _gameState . _playerXpos , _gameState .
        _playerYpos ) ;
        }
}


public override void PerformCollisionDetection ()
{
    foreach ( Entity s in _entities )
    {
        if ( s != Player )
        {
            if ( s is Obstacle )
            {
                if ( s . CollidesWith ( Player ) )
                    {
                        PlayerDeath () ;
                    }
            }
            
            if ( s is Platform )
            {
                if ( s . CollidesWith ( Player ) )
                {
                    if ( _pm . PO . Distance () > 4.00)
                        {
                            PlayerDeath () ;
                        }
                        _pm . PO . VelocityZero () ;
                }
            }
        }
    }

    if ( _customer . CollidesWith ( Player ) )
    {
        _entities . Remove ( _customer ) ;
        _isCustomerAlive = false ;
    }
}