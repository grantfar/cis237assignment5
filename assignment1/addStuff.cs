//CSVcontroller
public void AddWine(wineItem addedWine)
{
	StreamWriter wineWriter = File.AppendText(csvPathString);
	wineWriter.WriteLine(addedWine.WineId+ "," + addedWine.WineDescription + "," + addedWine.WinePack);
	wineWriter.close();
}
//wineItemCollection
public void AddWine2(wineItem addedWine)
{
	list<wineItem> temp = collectionArray;
	temp.add(addedWine);
	collectionArray = temp.ToArray()
}

//wineItem
public WineId
{
	get
	{
		return wineId;
	}
}

public WineDescription
{
	get
	{
		return wineDescription;
	}
}

public WinePack
{
	get
	{
		return winePack;
	}
}