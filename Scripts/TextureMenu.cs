using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Other.Extensions;
using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using Com.TheFallenGames.OSA.DataHelpers;
using Com.TheFallenGames.OSA.CustomParams;

namespace TextureGrids.Grids
{
	public class TextureMenu : GridAdapter<GridParams, MyGridItemViewsHolder>
	{  
	  public Scriptable scriptable;
	  
	  
		
		public SimpleDataHelper<SphereClass> Data { get; private set; }
		
		#region GridAdapter implementation    
		protected override void Start()
		{
			Data = new SimpleDataHelper<SphereClass>(this);

			
			base.Start();
			RetrieveDataAndUpdate(scriptable.sphereData.Length);
		}

		
		protected override void UpdateCellViewsHolder(MyGridItemViewsHolder newOrRecycled)
		{
			SphereClass model = Data[newOrRecycled.ItemIndex];

			newOrRecycled.Update( model);
		}

		
		#endregion

		
		#region data manipulation
		public void AddItemsAt(int index, IList<SphereClass> items)
		{
			
			Data.List.InsertRange(index, items);
			Data.NotifyListChangedExternally();
		}

		public void RemoveItemsFrom(int index, int count)
		{
			
			Data.List.RemoveRange(index, count);
			Data.NotifyListChangedExternally();
		}

		public void SetItems(IList<SphereClass> items)
		{
			Data.ResetItems(items);
		}
		#endregion


		
		void RetrieveDataAndUpdate(int count)
		{
			StartCoroutine(FetchMoreItemsFromDataSourceAndUpdate(count));

		}

		
		IEnumerator FetchMoreItemsFromDataSourceAndUpdate(int count)
		{
			
			yield return new WaitForSeconds(.5f);
            
			OnDataRetrieved(scriptable.sphereData);
		}

		void OnDataRetrieved(SphereClass[] newItems)
		{
			Data.List.AddRange(newItems);
			Data.NotifyListChangedExternally();
		}
	}


	public class MyGridItemViewsHolder : CellViewsHolder
	{
		public SphereClass sp;
		public Image backgroundImage;
		private AdapterViewItem item;

		public override void CollectViews()
		{
			base.CollectViews();
			item = root.GetComponent<AdapterViewItem>();
		    views.GetComponent<AdapterViewItem>();
		}
		
	
	  public void Update(SphereClass sp)
		{
          item.UpdateView(sp);
		}
		
		
	}
}
