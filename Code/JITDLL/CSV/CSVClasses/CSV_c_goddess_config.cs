using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class CSV_c_goddess_config : CSVBase
{
	#region data
	//<BeginAttribute>
	public int GoddessId;
	public string GoddessName;
	public int GoddessSkillId;
	public float ColdTime;
	public string HeadIconAtlas;
	public string HeadIcon;
	public string Prefab;


	#endregion
	
	private static bool IsInited
	{
		get
		{
			return csv_data.Count > 0;
		}
	}
	
	private static List<CSV_c_goddess_config> csv_data = new List<CSV_c_goddess_config>();
	
	/// <summary>
    /// 初始化 
    /// </summary>
	private static void InitCSVTable()
	{
		CSVDataFile new_file = new CSVDataFile();

		TextAsset ta;
		#if !USE_ASSETBUNDLE
		ta = Resources.Load("Configs/csv/c_csv/c_goddess_config", typeof(TextAsset)) as TextAsset;
		#else
		ta = AssetBundles.AssetBundleManager.Instance.LoadSync<TextAsset>("Configs/csv/c_csv/c_goddess_config", AssetBundles.E_Resource_Type.Normal, true);
		#endif

		if (ta == null)
			return;

		new_file.ParseCSVFor( ta );
		
		int row_index = 2;
		
		while( new_file.SetRow( row_index ) )
		{
			CSV_c_goddess_config item 		= new CSV_c_goddess_config();

			//<BeginAssign>
			item.GoddessId = new_file.GetInt("GoddessId");
			item.GoddessName = new_file.GetString("GoddessName");
			item.GoddessSkillId = new_file.GetInt("GoddessSkillId");
			item.ColdTime = new_file.GetFloat("ColdTime");
			item.HeadIconAtlas = new_file.GetString("HeadIconAtlas");
			item.HeadIcon = new_file.GetString("HeadIcon");
			item.Prefab = new_file.GetString("Prefab");

			
            item.OnReadRow(new_file);
			csv_data.Add( item );
			
			row_index++;
		}
	}

	/// <summary>
    /// 通过索引取得数据 
    /// </summary>
    /// <param name="index">索引</param>
    /// <returns>CSV的一行数据</returns>
	public static CSV_c_goddess_config GetData( int index )
	{
		if( IsInited == false )
		{
			InitCSVTable();
		}
		
		int i = index;
		if( i < 0 ) i = 0;
		if( i >= csv_data.Count ) i = csv_data.Count - 1;
		
		return csv_data[i];
	}
	
	/// <summary>
    /// 通过键值取得数据 
    /// </summary>
    /// <param name="index">键值</param>
    /// <returns>CSV的一行数据</returns>
    public static CSV_c_goddess_config FindData(int index)
    {
        if (IsInited == false)
        {
            InitCSVTable();
        }

        return csv_data.Find( x => x.GoddessId == index );
    }

	/// <summary>
    /// 通过键值取得数据
    /// </summary>
    /// <param name="index">键值</param>
    /// <returns>满足条件的所有数据</returns>
	public static List<CSV_c_goddess_config> FindAll(int index)
    {
        if (IsInited == false)
        {
            InitCSVTable();
        }

        return csv_data.FindAll( x => x.GoddessId == index );
    }

	/// <summary>
    /// 数据总行数 
    /// </summary>
	public static int DateCount
	{
		get
		{
			if (IsInited == false)
			{
				InitCSVTable();
			}

			return csv_data.Count;
		}
	}
	
	/// <summary>
    /// 返回所有数据
    /// </summary>
	public static List<CSV_c_goddess_config> AllData
	{
		get
		{
			if (IsInited == false)
			{
				InitCSVTable();
			}
			return csv_data;
		}
	}

	/// <summary>
    /// 清除数据，释放内存
    /// </summary>
	public static void Recycle()
	{
		csv_data.Clear();
	}
}


