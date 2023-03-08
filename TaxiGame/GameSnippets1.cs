Using System;


public virtual void RotateFlip ()
{
    _pixbuf = _pixbuf.RotateSimple(PixbufRotation.Upsidedown);
    _pixbuf = _pixbuf.Flip(false) ;
}


public void GetPath ()
{
    var path = AppDomain.CurrentDomain.BaseDirectory;
    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
    path + " Levels ");
    _path = path;
}

public void GetLevels ( string path )
{
    string [] files = Directory.GetFiles(path,"*.txt") ;

    var sort = from s in files orderby s select s ;

    foreach ( string s in sort )
        {
            _levels.Add(s) ;
        }
}


public void ParseASCII ( string [] levelFile )
{
    for( int i = 0; i < 23; i ++)
    {
        _ASCII [ i ] = levelFile [ i ];
    }
}


public void Deserialize ( string fileNumber )
{
    var path = AppDomain.CurrentDomain.BaseDirectory + "
    SaveFiles " + Path.DirectorySeparatorChar + " DataFile " +
    fileNumber + ".dat";
    FileStream fs = new FileStream (path, FileMode.Open) ;

    BinaryFormatter formatter = new BinaryFormatter () ;

    try
        {
            _gameState = ( GameState ) formatter.Deserialize(fs) ;
        }
    catch ( SerializationExceptione)
        {
            Console.WriteLine(e.Message) ;
            throw;
        }
    finally
        {
            fs.Close();
        }
}



